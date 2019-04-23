using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Domain;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;

using Repository;
using SogyoLunchApp;
using SogyoLunchApp.APIService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Google.Apis.Services;
using Google.Apis.Oauth2.v2;
using System.Text;

namespace Services
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;
        private readonly HelperClass _helper;

        public Startup(IConfiguration configuration, ILogger<Startup> logger, HelperClass helper)
        {
            Configuration = configuration;
            _logger = logger;
            _helper = helper;
        }

        // Gedeelte om CORS toe te staan voor makkelijker development. Verwijderen bij in productie nemen.
        readonly string AllowAllOrigins = "_AllowAllOrigins";
        // Einde development code

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureOptions(services)
                .ConfigureDatabase(services)
                .ConfigureAuthentication(services)
                .ConfigureExternalAuthentication(services)
                .ConfigureMvc(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            AppInitializeDatbase(app)
                .AppAddUses(app, env.IsDevelopment());
        }

        public Startup AppInitializeDatbase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider
                    .GetRequiredService<LunchAppContext>();
                var userManager = serviceScope.ServiceProvider
                    .GetRequiredService<UserManager<AppUser>>();
                var roleManager = serviceScope.ServiceProvider
                    .GetRequiredService<RoleManager<AppRole>>();

                var initializer = new DBInitializer(
                    context,
                    userManager,
                    roleManager
                );

                initializer.Migrate().Wait();
                initializer.SeedAll().Wait();
            }
            return this;
        }

        public Startup AppAddUses(IApplicationBuilder app, bool isDevelopment)
        {
            if (isDevelopment)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                await next();
                var path = context.Request.Path.Value;
                if (context.Response.StatusCode == 404 && !Path.HasExtension(path) && !path.StartsWith("/sogyolunchapi"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseCors(AllowAllOrigins);
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
            app.UseHealthChecks("/health");

            return this;
        }

        public Startup ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<LunchAppContext>(options =>
            {
                options.UseSqlServer(
                    _helper.GetConnectionStringWithPassword(Configuration, "LanthirDatabase"),
                        provider =>
                        {
                            provider.EnableRetryOnFailure();
                            provider.MigrationsAssembly("Services");
                        });
            });

            services.AddScoped<DBoperations>();

            services.AddDataProtection()
                .SetApplicationName("Lanthir Lunch")
                .PersistKeysToDbContext<LunchAppContext>();

             services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<LunchAppContext>()
                .AddTokenProvider<RefreshTokenProvider>(RefreshTokenProvider.Name)
                .AddDefaultTokenProviders();

            return this;
        }

        public Startup ConfigureMvc(IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<LunchAppContext>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(AppPolicies.OnlyAdmin, policy =>
                    policy.RequireRole(AppRole.AdminRole)
                );
            });

            services.AddMvc(options =>
            {
                // Allow only authenticated users
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy(AllowAllOrigins, builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            return this;
        }

        public Startup ConfigureExternalAuthentication(IServiceCollection services)
        {
            services.AddSingleton<Oauth2Service>(new Oauth2Service(
                new BaseClientService.Initializer
                {

                }
            ));
            services.AddSingleton<IExternalLoginProvider, GoogleLoginProvider>();

            // Service to access external login providers by name
            services.AddSingleton<Func<string, IExternalLoginProvider>>(serviceProvider => providerName =>

                 serviceProvider.GetServices<IExternalLoginProvider>().FirstOrDefault(
                    service => service.Name.Equals(providerName, StringComparison.InvariantCulture)
                )
            );
            return this;
        }

        public Startup ConfigureOptions(IServiceCollection services) {
            services.AddSingleton<JwtOptions>(new JwtOptions
            {
                Issuer = Configuration["Jwt:Issuer"],
                Audience = Configuration["Jwt:Issuer"],
                ExpiryMinutes = Int32.Parse(Configuration["Jwt:ExpiryMinutes"]),
                Credentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"])),
                    SecurityAlgorithms.HmacSha256
                )
            });
            return this;
        }

        public Startup ConfigureAuthentication(IServiceCollection services) {
            services.AddSingleton<JwtIssuer>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var jwtOptions = serviceProvider.GetService<JwtOptions>();

                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = jwtOptions.Credentials.Key,
                    ClockSkew = TimeSpan.FromSeconds(30)
                };
                options.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = async context =>
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "text/plain";

                        //await c.Response.WriteAsync(c.Exception.ToString());
                    },
                    OnTokenValidated = async context =>
                    {
                        var userManager = context.HttpContext.RequestServices
                            .GetService<UserManager<AppUser>>();
                        var user = await userManager.GetUserAsync(context.Principal);

                        var token = await userManager.GetAuthenticationTokenAsync(
                            user,
                            RefreshTokenProvider.Name,
                            RefreshTokenProvider.Purpose
                        );

                        var isValid = await userManager.VerifyUserTokenAsync(
                            user,
                            RefreshTokenProvider.Name,
                            RefreshTokenProvider.Purpose,
                            token
                        );

                        if (!isValid)
                        {
                            context.Fail("The stored token was invalidated");
                        }
                    }
                };
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SogyoLunchApp;

namespace Repository {
    public class DBInitializer {
        private readonly LunchAppContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public DBInitializer(
            LunchAppContext context,
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager
        ) {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAll() {
            await SeedUsers();
        }

        public async Task EnsureCreated() {
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task Migrate() {
            await _context.Database.MigrateAsync();
        }

        public async Task SeedUsers() {
            await _roleManager.CreateAsync(new AppRole { Name = AppRole.AdminRole });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;


namespace SogyoLunchApp.APIService
{
    public class HelperClass
    {
        private static ILogger<HelperClass> _logger;

        public HelperClass(ILogger<HelperClass> logger) {
            _logger = logger;
        }

        /**
         * class for helper methods used by the API.
         * i.e. mappen naar objecten etc.
         **/

        public static DateTime ParseDateTime(string date) 
        {

                string year = date.ToCharArray().GetValue(4).ToString() + date.ToCharArray().GetValue(5).ToString() +
                              date.ToCharArray().GetValue(6).ToString() + date.ToCharArray().GetValue(7).ToString();
                string month = date.ToCharArray().GetValue(2).ToString() + date.ToCharArray().GetValue(3).ToString();
                string day = date.ToCharArray().GetValue(0).ToString() + date.ToCharArray().GetValue(1).ToString();
                string time = "";

                if (date.Length > 8)
                {
                    for (int x = 9; x < 17; x++)
                    {
                        time += date.ToCharArray().GetValue(x).ToString();
                    }
                }
                else
                {
                    time = "12:00:00";
                }

                return DateTime.Parse(year + "/" + month + "/" + day + " " + time);

        }

        // Get a named connection string from the configuration and allow overriding the credentials
        public string GetConnectionStringWithPassword(IConfiguration configuration, string name)
        {
            string connectionString = configuration?.GetSection("ConnectionStrings")?[name];
            if (String.IsNullOrEmpty(connectionString)) return connectionString;

            IConfigurationSection providedCredentials = configuration?
                .GetSection("ConnectionStrings")?.GetSection(name + "_Credentials");
            if (providedCredentials == null) return connectionString;

            string username = providedCredentials["Username"];
            string password = providedCredentials["Password"];
            if (String.IsNullOrEmpty(password) || string.IsNullOrEmpty(username)) {
                _logger.LogWarning(String.Format("Missing required parameters \"Username\" and \"Password\" for connection string \"{0}\"", name));
                return connectionString;
            }

            var credentials = new Dictionary<string, string>() {
                { "User Id", username },
                { "Password", password }
            };

            string pattern = @"(?i)(User Id|Password)=([^;]*)";
            return Regex.Replace(connectionString, pattern, m => 
                 String.Format("{0}={1}", m.Groups[1].Value, credentials[m.Groups[1].Value]));
        }
    }
}

using System;
using Microsoft.Extensions.Configuration;

namespace ERO
{
    public class ApplicationConfiguration
    {
        private static IConfigurationRoot value;

        public static IConfigurationRoot Get()
        {
            if (value == null) 
            {
                value = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile(@$"appsettings.json")
#if DEBUG
                    .AddJsonFile($@"appsettings.development.json", optional: true)
#endif
                    .Build();

                return value;
            }

            return value;
        }
    }
}
using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace PooLojaVirtual.Infraestructure
{
    public class ConfigurationService
    {
        public static IConfiguration GetConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../PooLojaVirtual.Web"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json")
                .Build();
        }
    }
}
using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.FileProviders;
using System;
using Microsoft.Extensions.Hosting;

namespace OPM
{
    public static class AppConfigurations
    {
        private static bool _hasInit = false;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void InitAppConfiguration(bool IsDevelopment)
        {
            if (_hasInit)
            {
                throw new Exception("GlobalEnvironment Has Inited");
            }
            if (IsDevelopment)
            {
                IsDevelopmentEnvironment = true;
            }
            ContentRootPath = Environment.CurrentDirectory;
           //ContentRootFileProvider = env.ContentRootFileProvider;
            SeverHost = IsDevelopment ? "https://soa-dev.lonsid.cn" : "https://soa.lonsid.cn";
            EnvironmentName = IsDevelopment? "Development":"Production";
            _hasInit = true;
        }

        public static bool IsDevelopmentEnvironment { get; private set; } = false;


        public static string Directory => Environment.CurrentDirectory;


        public static string ApplicationName => "OPM";


        public static IFileProvider ContentRootFileProvider { get; private set; }

        public static string ContentRootPath { get; private set; }


        public static string SeverHost { get; private set; }

        public static string EnvironmentName { get; private set; }


        private static readonly ConcurrentDictionary<string, IConfigurationRoot> _configurationCache;

        static AppConfigurations()
        {
            _configurationCache = new ConcurrentDictionary<string, IConfigurationRoot>();
        }

        public static IConfigurationRoot Get(string path, bool addUserSecrets = false)
        {
            var cacheKey = path + "#" + EnvironmentName + "#" + addUserSecrets;
            return _configurationCache.GetOrAdd(
                cacheKey,
                _ => BuildConfiguration(path, addUserSecrets)
            );
        }

        private static IConfigurationRoot BuildConfiguration(string path, bool addUserSecrets = false)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (!EnvironmentName.IsNullOrWhiteSpace())
            {
                builder = builder.AddJsonFile($"appsettings.{EnvironmentName}.json", optional: true);
            }

            builder = builder.AddEnvironmentVariables();

            if (addUserSecrets)
            {
                builder.AddUserSecrets(typeof(AppConfigurations).Assembly);
            }

            return builder.Build();
        }
    }
}

using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Sardinia;
using R5T.Suebia;

using RawGitConfiguration = R5T.Nikaia.Configuration.Raw.GitConfiguration;


namespace R5T.Nikaia.Configuration.Suebia
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddGitConfiguration(this IServiceCollection services)
        {
            services
                .Configure<RawGitConfiguration>()
                .ConfigureOptions<GitConfigurationConfigureOptions>()
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GitJsonConfigurationFilePathProvider"/> implementation of <see cref="IGitJsonConfigurationFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGitJsonConfigurationFilePathProvider(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            services
                .AddSingleton<IGitJsonConfigurationFilePathProvider, GitJsonConfigurationFilePathProvider>()
                .Run(secretsDirectoryFilePathProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GitJsonConfigurationFilePathProvider"/> implementation of <see cref="IGitJsonConfigurationFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IGitJsonConfigurationFilePathProvider> AddGitJsonConfigurationFilePathProviderAction(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            var serviceAction = ServiceAction.New<IGitJsonConfigurationFilePathProvider>(() => services.AddGitJsonConfigurationFilePathProvider(
                secretsDirectoryFilePathProviderAction));

            return serviceAction;
        }
    }
}

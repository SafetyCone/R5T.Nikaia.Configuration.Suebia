using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Suebia;


namespace R5T.Nikaia.Configuration.Suebia
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="GitConfigurationJsonFilePathProvider"/> implementation of <see cref="IGitConfigurationJsonFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddGitConfigurationJsonFilePathProvider(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            services
                .AddSingleton<IGitConfigurationJsonFilePathProvider, GitConfigurationJsonFilePathProvider>()
                .Run(secretsDirectoryFilePathProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="GitConfigurationJsonFilePathProvider"/> implementation of <see cref="IGitConfigurationJsonFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IGitConfigurationJsonFilePathProvider> AddGitConfigurationJsonFilePathProviderAction(this IServiceCollection services,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction)
        {
            var serviceAction = ServiceAction.New<IGitConfigurationJsonFilePathProvider>(() => services.AddGitConfigurationJsonFilePathProvider(
                secretsDirectoryFilePathProviderAction));

            return serviceAction;
        }
    }
}

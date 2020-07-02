using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Suebia;


namespace R5T.Nikaia.Configuration.Suebia
{
    public static class IConfigurationBuilderExtensions
    {
        /// <summary>
        /// Uses the <see cref="ISecretsDirectoryFilePathProvider"/> service (and <see cref="FileNames.GitConfigurationJsonFileName"/>).
        /// </summary>
        public static IConfigurationBuilder AddGitConfigurationJsonFileFromSecretsDirectory(this IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            var secretsFilePathProvider = configurationServiceProvider.GetRequiredService<ISecretsDirectoryFilePathProvider>();

            var gitConfigurationJsonFilePath = secretsFilePathProvider.GetSecretsFilePath(FileNames.GitConfigurationJsonFileName);

            configurationBuilder.AddJsonFile(gitConfigurationJsonFilePath);

            return configurationBuilder;
        }

        /// <summary>
        /// Uses the <see cref="IGitConfigurationJsonFilePathProvider"/> service.
        /// </summary>
        public static IConfigurationBuilder AddGitConfigurationJsonFileDirect(this IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            var gitJsonConfigurationFilePathProvider = configurationServiceProvider.GetRequiredService<IGitConfigurationJsonFilePathProvider>();

            var gitConfigurationJsonFilePath = gitJsonConfigurationFilePathProvider.GetGitConfigurationJsonFilePath();

            configurationBuilder.AddJsonFile(gitConfigurationJsonFilePath);

            return configurationBuilder;
        }

        /// <summary>
        /// Default uses the <see cref="AddGitConfigurationJsonFileDirect(IConfigurationBuilder, IServiceProvider)"/> method.
        /// </summary>
        public static IConfigurationBuilder AddGitConfigurationJsonFile(this IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            configurationBuilder.AddGitConfigurationJsonFileDirect(configurationServiceProvider);

            return configurationBuilder;
        }
    }
}

using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace R5T.Nikaia.Configuration.Suebia
{
    public static class IConfigurationBuilderExtensions
    {
        /// <summary>
        /// Uses the <see cref="IGitConfigurationJsonFilePathProvider"/> service.
        /// </summary>
        public static IConfigurationBuilder AddGitConfigurationJsonFile(this IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            var gitJsonConfigurationFilePathProvider = configurationServiceProvider.GetRequiredService<IGitConfigurationJsonFilePathProvider>();

            var gitConfigurationJsonFilePath = gitJsonConfigurationFilePathProvider.GetGitConfigurationJsonFilePath();

            configurationBuilder.AddJsonFile(gitConfigurationJsonFilePath);

            return configurationBuilder;
        }
    }
}

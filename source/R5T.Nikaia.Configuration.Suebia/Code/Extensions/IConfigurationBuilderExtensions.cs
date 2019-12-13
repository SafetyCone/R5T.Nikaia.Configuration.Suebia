using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Suebia;


namespace R5T.Nikaia.Configuration.Suebia
{
    public static class IConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddGitConfigurationJsonFile(this IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            var secretsFilePathProvider = configurationServiceProvider.GetRequiredService<ISecretsFilePathProvider>();

            var gitConfigurationJsonFilePath = secretsFilePathProvider.GetSecretsFilePath(FileNames.GitConfigurationJsonFileName);

            configurationBuilder.AddJsonFile(gitConfigurationJsonFilePath);

            return configurationBuilder;
        }
    }
}

using System;

using R5T.Suebia;using R5T.T0064;


namespace R5T.Nikaia.Configuration.Suebia
{[ServiceImplementationMarker]
    public class GitConfigurationJsonFilePathProvider : IGitConfigurationJsonFilePathProvider,IServiceImplementation
    {
        private ISecretsDirectoryFilePathProvider SecretsDirectoryFilePathProvider { get; }


        public GitConfigurationJsonFilePathProvider(ISecretsDirectoryFilePathProvider secretsDirectoryFilePathProvider)
        {
            this.SecretsDirectoryFilePathProvider = secretsDirectoryFilePathProvider;
        }

        public string GetGitConfigurationJsonFilePath()
        {
            var gitConfigurationJsonFilePath = this.SecretsDirectoryFilePathProvider.GetSecretsFilePath(FileNames.GitConfigurationJsonFileName);
            return gitConfigurationJsonFilePath;
        }
    }
}

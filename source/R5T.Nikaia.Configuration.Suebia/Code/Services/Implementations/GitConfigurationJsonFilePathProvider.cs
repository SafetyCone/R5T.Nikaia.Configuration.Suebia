using System;

using R5T.Suebia;


namespace R5T.Nikaia.Configuration.Suebia
{
    public class GitConfigurationJsonFilePathProvider : IGitConfigurationJsonFilePathProvider
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

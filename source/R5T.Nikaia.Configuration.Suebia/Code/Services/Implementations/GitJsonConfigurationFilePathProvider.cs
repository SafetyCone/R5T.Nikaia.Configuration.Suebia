using System;
using System.Threading.Tasks;

using R5T.Suebia;


namespace R5T.Nikaia.Configuration.Suebia
{
    public class GitJsonConfigurationFilePathProvider : IGitJsonConfigurationFilePathProvider
    {
        private ISecretsDirectoryFilePathProvider SecretsDirectoryFilePathProvider { get; }


        public GitJsonConfigurationFilePathProvider(ISecretsDirectoryFilePathProvider secretsDirectoryFilePathProvider)
        {
            this.SecretsDirectoryFilePathProvider = secretsDirectoryFilePathProvider;
        }

        public Task<string> GetGitJsonConfigurationFilePath()
        {
            var gitConfigurationJsonFilePath = this.SecretsDirectoryFilePathProvider.GetSecretsFilePath(FileNames.GitConfigurationJsonFileName);

            return Task.FromResult(gitConfigurationJsonFilePath);
        }
    }
}

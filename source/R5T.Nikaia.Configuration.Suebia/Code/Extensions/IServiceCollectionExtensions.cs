using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Sardinia;

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
    }
}

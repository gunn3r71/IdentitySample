using App.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace App.Config
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddAuthorizationConfig(this IServiceCollection services)
        {
            services.AddAuthorization(o =>
            {
                o.AddPolicy("PodeExcluir", p => p.RequireClaim("PodeExcluir"));
                o.AddPolicy("PodeLer", p => p.Requirements.Add(new PermissaoNecessaria("PodeLer")));
                o.AddPolicy("PodeEscrever", p => p.Requirements.Add(new PermissaoNecessaria("PodeEscrever")));
            });

            return services;
        }
    }
}

using Microsoft.AspNetCore.Authorization;

namespace App.Extensions
{
    public class PermissaoNecessaria : IAuthorizationRequirement
    {
        public PermissaoNecessaria(string permissao)
        {
            Permissao = permissao;
        }
        public string Permissao { get; set; }
    }
}

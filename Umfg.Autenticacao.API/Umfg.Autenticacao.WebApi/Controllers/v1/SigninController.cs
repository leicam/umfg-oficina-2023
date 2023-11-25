using Microsoft.AspNetCore.Mvc;
using Ufmg.Autenticacao.Dominio.Interfaces.Servicos;

namespace Umfg.Autenticacao.WebApi.Controllers.v1
{
    public sealed class SigninController : AbstractControllerV1
    {
        private readonly IAutenticacaoServico _servico;

        public SigninController(IAutenticacaoServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public IActionResult Ping() => Ok();
    }
}
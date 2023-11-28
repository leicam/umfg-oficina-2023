using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ufmg.Autenticacao.Dominio.Constantes;

namespace Umfg.Autenticacao.WebApi.Controllers.v1
{
    public sealed class HelthcheckController : AbstractControllerV1
    {
        [HttpGet]
        [Authorize(Roles = $"{Role.Padrao}, ")]
        public IActionResult Ping() => Ok();
    }
}
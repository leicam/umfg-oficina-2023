using Microsoft.AspNetCore.Mvc;

namespace Umfg.Autenticacao.WebApi.Controllers.v1
{
    public sealed class HelthcheckController : AbstractControllerV1
    {
        [HttpGet]
        public IActionResult Ping() => Ok();
    }
}
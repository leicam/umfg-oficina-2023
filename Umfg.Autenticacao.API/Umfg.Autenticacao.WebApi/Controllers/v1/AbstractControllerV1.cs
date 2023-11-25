using Microsoft.AspNetCore.Mvc;

namespace Umfg.Autenticacao.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("v1/[controller]")]
    public abstract class AbstractControllerV1 : AbstractController { }
}
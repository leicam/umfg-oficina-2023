using Microsoft.AspNetCore.Mvc;

namespace Umfg.Autenticacao.WebApi.Controllers
{
    [ApiController]
    public abstract class AbstractController : ControllerBase
    {
        protected async Task<IActionResult> InvokeMethodAsync<T>(Func<T, Task> method, T args)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(GetModelStateMessageErrors());

                await method.Invoke(args);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected async Task<IActionResult> InvokeMethodAsync<T, TResult>(
            Func<T, Task<TResult>> method, T args)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(GetModelStateMessageErrors());

                return Ok(await method.Invoke(args));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string GetModelStateMessageErrors()
            => string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
    }
}
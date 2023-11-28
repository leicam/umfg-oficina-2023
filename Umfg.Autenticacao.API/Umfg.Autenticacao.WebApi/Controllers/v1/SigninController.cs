using Microsoft.AspNetCore.Mvc;
using Ufmg.Autenticacao.Dominio.Interfaces.Servicos;
using Umfg.Autenticacao.DTO.Classes;

namespace Umfg.Autenticacao.WebApi.Controllers.v1
{
    public sealed class SigninController : AbstractControllerV1
    {
        private readonly IAutenticacaoServico _servico;

        public SigninController(IAutenticacaoServico servico) => _servico = servico;

        /// <summary>
        /// Método responsavél pelo login do usuário
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] UsuarioDTO.SingIn dto)
            => await InvokeMethodAsync(_servico.LoginAsync, dto);
    }
}
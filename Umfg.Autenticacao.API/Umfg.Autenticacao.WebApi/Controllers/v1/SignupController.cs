using Microsoft.AspNetCore.Mvc;
using Ufmg.Autenticacao.Dominio.Interfaces.Servicos;
using Umfg.Autenticacao.DTO.Classes;

namespace Umfg.Autenticacao.WebApi.Controllers.v1
{
    public sealed class SignupController : AbstractControllerV1
    {
        private readonly IAutenticacaoServico _servico;

        public SignupController(IAutenticacaoServico servico) 
            => _servico = servico;

        /// <summary>
        /// Método responsavel pelo cadastro de um novo usuário
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CadastrarAsync([FromBody] UsuarioDTO.SingUp dto)
            => await InvokeMethodAsync(_servico.CadastrarAsync, dto);
    }
}
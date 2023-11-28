using Umfg.Autenticacao.DTO.Classes;

namespace Ufmg.Autenticacao.Dominio.Interfaces.Servicos
{
    public interface IAutenticacaoServico
    {
        Task CadastrarAsync(UsuarioDTO.SingUp dto);
        Task<UsuarioDTO.SingInResponse> LoginAsync(UsuarioDTO.SingIn dto);
    }
}
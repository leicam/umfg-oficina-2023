using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Umfg.Autenticacao.DTO.Classes
{
    public sealed class UsuarioDTO
    {
        public abstract class AbstractUsuarioDTO
        {
            [JsonPropertyName("email")]
            [Required(ErrorMessage = "O campo {0} é obrigatório!")]
            [EmailAddress(ErrorMessage = "O campo {0} é inválido!")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string Email { get; set; } = string.Empty;

            [JsonPropertyName("password")]
            [Required(ErrorMessage = "O campo {0} é obrigatório!")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e caracteres!", MinimumLength = 6)]
            public string Password { get; set; } = string.Empty;
        }

        public sealed class SingIn : AbstractUsuarioDTO { }

        public sealed class SingInResponse
        {
            [JsonPropertyName("acessToken")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string AcessToken { get; set; } = string.Empty;

            [JsonPropertyName("refreshToken")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string RefreshToken { get; set; } = string.Empty;
        }

        public sealed class SingUp : AbstractUsuarioDTO 
        {
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [Compare(nameof(Password), ErrorMessage = "As senhas devem ser iguais!")]
            public string ConfirmedPassword { get; set; } = string.Empty;
        }
    }
}
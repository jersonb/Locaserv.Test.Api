using System.ComponentModel.DataAnnotations;

namespace Locaserv.Test.Api.Controllers
{
    public class User
    {
        [Required(ErrorMessage = "Necessário informar o {0}")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; } = default!;

        [Required(ErrorMessage = "Necessário informar a {0}")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; } = default!;

        [Required]
        [Display(Name = "Lembrar-se")]
        public bool RememberMe { get; set; } = false;
    }
}
using System.ComponentModel.DataAnnotations;

namespace KnotExe.Models
{
    public class Usuario
    {
        [Key]
        [Display(Name = "Chave")]
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Nome de Exibição")]
        [Display(Name = "Nome De Exibição")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome de Exibição deve ter entre 3 a 100 caracteres")]
        public string UsuNome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Nome de Usuário")]
        [Display(Name = "Nome de Usuário")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome de Usuário deve ter entre 3 a 100 caracteres")]
        public string UsuUsername { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: E-Mail")]
        [Display(Name = "E-Mail")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        public string UsuEmail { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Senha")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Insira uma Senha válida")]
        public string UsuSenhaHash { get; set; }

        [StringLength(255)]
        public string UsuBio { get; set; }
        public string UsuTipo { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}

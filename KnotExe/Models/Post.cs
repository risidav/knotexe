using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnotExe.Models
{
    public class Post
    {
        [Key]
        [Display(Name = "Chave")]
        public int idPost { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Texto")]
        [Display(Name = "Texto da Postagem")]
        [StringLength(255)]
        public string PosTexto { get; set; }
        public string? PosMedia { get; set; }
        public DateTime PosData { get; set; }

        public string PosTipo { get; set; }

        [ForeignKey("Usuario")]
        public int PosidUsuario { get; set; }
        public Usuario? Usuario { get; set; }
    }
}

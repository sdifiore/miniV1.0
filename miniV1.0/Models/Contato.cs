using System.ComponentModel.DataAnnotations;

namespace miniV1.Models
{
    public class Contato
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Nome { get; set; }

        [Required]
        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(64)]
        public string Telefone { get; set; }

        [StringLength(5120)]
        public string Comentario { get; set; }
    }
}

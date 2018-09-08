using System.ComponentModel.DataAnnotations;

namespace miniV1.Models
{
    public class Contato
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        public string Telefone { get; set; }

        [Required]
        public string Comentario { get; set; }
    }
}

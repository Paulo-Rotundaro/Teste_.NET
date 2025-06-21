using System.ComponentModel.DataAnnotations;

namespace ZOSS.Teste.Back.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public required string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}

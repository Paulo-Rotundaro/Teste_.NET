using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOSS.Teste.Back.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "Máximo de 100 caracteres.")]
        public required string Name { get; set; }

        [StringLength(200, ErrorMessage = "Máximo de 200 caracteres.")]
        public required string Description { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "O valor deve ser positivo.")]
        public decimal Value { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}

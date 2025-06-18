using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOSS.Teste.Back.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome � obrigat�rio.")]
        [StringLength(100, ErrorMessage = "M�ximo de 100 caracteres.")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "M�ximo de 200 caracteres.")]
        public string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O valor deve ser positivo.")]
        public double Value { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}

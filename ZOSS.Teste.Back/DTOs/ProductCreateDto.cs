namespace ZOSS.Teste.Back.Models
{
    public class ProductCreateDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public int CategoryId { get; set; }
    }
}

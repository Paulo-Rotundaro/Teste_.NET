namespace ZOSS.Teste.Back.DTOs
{
    public class ProductResponseDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Value { get; set; }
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; } 
    }
}

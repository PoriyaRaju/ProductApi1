using System.ComponentModel.DataAnnotations;

namespace first_dotnet_app.DTOs.Requests
{
    public class UpdateProductRequest
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        public override string ToString()
        {
            return $"Name: {Name},Description: {Description} ,Price: {Price}";
        }
    }
}

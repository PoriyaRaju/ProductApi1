namespace first_dotnet_app.DTOs.Requests
{
    public class UpdateProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Name: {Name},Description: {Description} ,Price: {Price}";
        }
    }
}

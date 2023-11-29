namespace StoreProgram_lab4.DTO.Responses
{
    public class BasketWithClientInfoResponse
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string NumberPhone { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

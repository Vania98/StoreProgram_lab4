namespace StoreProgram_lab4.DTO.Responses
{
    public class BasketResponse
    {
        public int BasketID { get; set; }
        public int ClientID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

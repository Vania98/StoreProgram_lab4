using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProgram_lab4.Model
{
    public class Basket
    {
        public int BasketID { get; set; }

        public int ClientID { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public Client Client { get; set; }
    }
}

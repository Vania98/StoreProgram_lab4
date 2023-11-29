using System.ComponentModel.DataAnnotations;

namespace StoreProgram_lab4.Model
{
    public class Client
    {
        public int ClientID { get; set; }

        public string ClientName { get; set; }  = string.Empty;

        public string NumberPhone { get; set; } = string.Empty;
    }
}

namespace Grundlagen.Models
{
    public class AdressModel
    {
        public int AddressId { get; set; }
        public string City { get; set; } = "";
        public string Zip { get; set; } = "";
        public string Street { get; set; } = "";
        public string No { get; set; } = "";
        public int FedId { get; set; }

        public virtual FedStateModel FedState { get; set; }
    }
}


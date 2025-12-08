namespace Grundlagen.Models
{
    public class PersonModel
    {
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int? AddressId { get; set; }

        public virtual AdressModel Address
        {
            get; set;
        }


    }
}

using CruiseWorld.Models;

namespace CruiseWorld.Dtos
{
    public class AddressDto
    {
        public Guid AddressId { get; set; }

        public string AddressStreet { get; set; }

        public string AddressTown { get; set; }

        public string AddressPcode { get; set; }

        public string CountryName { get; set; }

    }
}

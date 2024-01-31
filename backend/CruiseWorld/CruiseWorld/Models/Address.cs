using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class Address
{
    public Guid AddressId { get; set; }

    public string AddressStreet { get; set; }

    public string AddressTown { get; set; }

    public string AddressPcode { get; set; }

    public string CountryCode { get; set; }

    // Basically the foreign key
    public virtual Country CountryCodeNavigation { get; set; }

    public virtual ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();
}

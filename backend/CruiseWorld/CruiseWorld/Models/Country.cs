using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class Country
{
    public string CountryCode { get; set; }

    public string CountryName { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Ship> Ships { get; set; } = new List<Ship>();
}

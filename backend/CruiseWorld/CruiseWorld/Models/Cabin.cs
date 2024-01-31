using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class Cabin
{
    public Guid ShipCode { get; set; }

    public Guid CabinNo { get; set; }

    public decimal CabinCapacity { get; set; }

    public string CabinClass { get; set; }

    public virtual ICollection<Manifest> Manifests { get; set; } = new List<Manifest>();

    public virtual Ship ShipCodeNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class Ship
{
    public Guid ShipCode { get; set; }

    public string ShipName { get; set; }

    public DateOnly ShipDateCommiss { get; set; }

    public decimal ShipTonnage { get; set; }

    public decimal ShipGuestCapacity { get; set; }

    public string CountryCode { get; set; }

    public Guid OperId { get; set; }

    public virtual ICollection<Cabin> Cabins { get; set; } = new List<Cabin>();

    public virtual Country CountryCodeNavigation { get; set; }

    public virtual ICollection<Cruise> Cruises { get; set; } = new List<Cruise>();

    public virtual Operator Oper { get; set; }
}

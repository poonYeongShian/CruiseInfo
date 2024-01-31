using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class Port
{
    public Guid PortCode { get; set; }

    public string PortName { get; set; }

    public decimal PortPopulation { get; set; }

    public decimal PortLong { get; set; }

    public decimal PortLat { get; set; }

    public string CountryCode { get; set; }

    public virtual ICollection<CruisePort> CruisePorts { get; set; } = new List<CruisePort>();

    public virtual ICollection<PortTemp> PortTemps { get; set; } = new List<PortTemp>();

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}

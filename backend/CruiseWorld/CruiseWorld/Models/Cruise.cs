using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class Cruise
{
    public Guid CruiseId { get; set; }

    public string CruiseName { get; set; }

    public string CruiseDescription { get; set; }

    public Guid ShipCode { get; set; }

    public virtual ICollection<CruisePort> CruisePorts { get; set; } = new List<CruisePort>();

    public virtual ICollection<Manifest> Manifests { get; set; } = new List<Manifest>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

    public virtual Ship ShipCodeNavigation { get; set; }
}

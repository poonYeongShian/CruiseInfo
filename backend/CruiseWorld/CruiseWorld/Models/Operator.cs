using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class Operator
{
    public Guid OperId { get; set; }

    public string OperCompName { get; set; }

    public string OperCeo { get; set; }

    public virtual ICollection<Ship> Ships { get; set; } = new List<Ship>();
}

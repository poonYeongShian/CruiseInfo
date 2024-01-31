using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class Manifest
{
    public Guid PassengerId { get; set; }

    public Guid CruiseId { get; set; }

    public DateOnly? MainfestBoardTime { get; set; }

    public Guid CabinNo { get; set; }

    public Guid ShipCode { get; set; }

    public virtual Cabin Cabin { get; set; }

    public virtual Cruise Cruise { get; set; }

    public virtual Passenger Passenger { get; set; }
}

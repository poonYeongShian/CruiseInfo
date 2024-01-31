using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class Participant
{
    public Guid ParticipantId { get; set; }

    public string TourPaid { get; set; }

    public Guid CruiseId { get; set; }

    public Guid PassengerId { get; set; }

    public DateOnly TourofferDate { get; set; }

    public Guid TourId { get; set; }

    public virtual Cruise Cruise { get; set; }

    public virtual Passenger Passenger { get; set; }

    public virtual Touroffer Touroffer { get; set; }
}

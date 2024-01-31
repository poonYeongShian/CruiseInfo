using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class Touroffer
{
    public DateOnly TourofferDate { get; set; }

    public Guid TourId { get; set; }

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

    public virtual Tour Tour { get; set; }
}

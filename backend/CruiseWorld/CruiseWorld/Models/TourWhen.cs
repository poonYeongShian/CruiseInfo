using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class TourWhen
{
    public Guid TourWhenCode { get; set; }

    public string TourWhenDesc { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}

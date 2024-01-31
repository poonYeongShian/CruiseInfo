using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class Language
{
    public string LangCode { get; set; }

    public string LangName { get; set; }

    public virtual ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}

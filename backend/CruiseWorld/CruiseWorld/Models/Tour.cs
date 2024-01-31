using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class Tour
{
    public Guid TourId { get; set; }

    public decimal TourNumber { get; set; }

    public string TourName { get; set; }

    public string TourDescription { get; set; }

    public decimal TourHours { get; set; }

    public decimal TourCostPp { get; set; }

    public string TourWchairAccess { get; set; }

    public DateOnly TourStarttime { get; set; }

    public decimal TourMinParticipants { get; set; }

    public Guid TourWhenCode { get; set; }

    public Guid PortCode { get; set; }

    public virtual Port PortCodeNavigation { get; set; }

    public virtual TourWhen TourWhenCodeNavigation { get; set; }

    public virtual ICollection<Touroffer> Touroffers { get; set; } = new List<Touroffer>();

    public virtual ICollection<Language> LangCodes { get; set; } = new List<Language>();
}

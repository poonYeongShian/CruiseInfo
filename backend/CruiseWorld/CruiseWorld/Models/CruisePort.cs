using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class CruisePort
{
    public Guid CruiseId { get; set; }

    public DateOnly CpDatetime { get; set; }

    public string CpDepartArrive { get; set; }

    public Guid PortCode { get; set; }

    public virtual Cruise Cruise { get; set; }

    public virtual Port PortCodeNavigation { get; set; }
}

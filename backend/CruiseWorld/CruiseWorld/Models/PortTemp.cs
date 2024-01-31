using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class PortTemp
{
    public Guid PortCode { get; set; }

    public DateOnly TempMonth { get; set; }

    public decimal? TempHigh { get; set; }

    public decimal? TempLow { get; set; }

    public virtual Port PortCodeNavigation { get; set; }
}

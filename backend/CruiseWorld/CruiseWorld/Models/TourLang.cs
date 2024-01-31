using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class TourLang
{
    public string LangCode { get; set; }

    public Guid TourId { get; set; }
}

using System;
using System.Collections.Generic;

namespace CruiseWorld.Models;

public partial class Passenger
{
    public Guid PassengerId { get; set; }

    public string PassengerFname { get; set; }

    public string PassengerLname { get; set; }

    public DateOnly PassengerDob { get; set; }

    public string PassengerGender { get; set; }

    public string PassengerContact { get; set; }

    public Guid AddressId { get; set; }

    public Guid? GuardianId { get; set; }

    public string LangCode { get; set; }

    public virtual Address Address { get; set; }

    public virtual Passenger Guardian { get; set; }

    public virtual ICollection<Passenger> InverseGuardian { get; set; } = new List<Passenger>();

    public virtual Language LangCodeNavigation { get; set; }

    public virtual ICollection<Manifest> Manifests { get; set; } = new List<Manifest>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}

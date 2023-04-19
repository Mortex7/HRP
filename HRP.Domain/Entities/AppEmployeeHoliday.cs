using System;
using System.Collections.Generic;

namespace HRP.Domain.Entities;

public partial class AppEmployeeHoliday
{
    public int IdEmployeeHoliday { get; set; }

    public int IdEmployee { get; set; }

    public DateTime? StartDate { get; set; }

    public int? DayCount { get; set; }

    public bool? IsApproved { get; set; }

    public DateTime? FactReleaseDate { get; set; }

    public int? Year { get; set; }

    public bool? IsPreferential { get; set; }

    public virtual RefEmployee IdEmployeeNavigation { get; set; } = null!;
}

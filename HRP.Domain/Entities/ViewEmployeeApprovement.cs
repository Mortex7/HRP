using System;
using System.Collections.Generic;

namespace HRP.Domain.Entities;

public partial class ViewEmployeeApprovement
{
    public int IdEmployeeHoliday { get; set; }

    public int IdEmployee { get; set; }

    public string? FullName { get; set; }

    public int? Year { get; set; }

    public DateTime? StartDate { get; set; }

    public int? DayCount { get; set; }

    public DateTime? FactReleaseDate { get; set; }

    public int? TotalDays { get; set; }

    public int? HolidayCount { get; set; }

    public int? MaxDayCount { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsPreferential { get; set; }

    public int IdSubdivision { get; set; }

    public int IdCategory { get; set; }

    public int IdPosition { get; set; }
}

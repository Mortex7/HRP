using System;
using System.Collections.Generic;

namespace HRP.Domain.Entities;

public partial class AppHolidayInYear
{
    public int IdHolidayInYear { get; set; }

    public int IdHoliday { get; set; }

    public DateTime? FactDate { get; set; }

    public DateTime? FactEndDate { get; set; }

    public int? Year { get; set; }

    public virtual RefHoliday IdHolidayNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace HRP.Domain.Entities;

public partial class RefHoliday
{
    public int IdHoliday { get; set; }

    public string? HolidayName { get; set; }

    public virtual ICollection<AppHolidayInYear> AppHolidayInYears { get; set; } = new List<AppHolidayInYear>();
}

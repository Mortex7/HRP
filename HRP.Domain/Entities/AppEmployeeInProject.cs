using System;
using System.Collections.Generic;

namespace HRP.Domain.Entities;

public partial class AppEmployeeInProject
{
    public int IdEmployeeInProject { get; set; }

    public int IdEmployee { get; set; }

    public int IdProject { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual RefEmployee IdEmployeeNavigation { get; set; } = null!;

    public virtual RefProject IdProjectNavigation { get; set; } = null!;
}

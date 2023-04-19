using System;
using System.Collections.Generic;

namespace HRP.Domain.Entities;

public partial class AppEmployeeControlGroupRole
{
    public int IdEmployeeControlGroupRole { get; set; }

    public int IdEmployee { get; set; }

    public int IdGroup { get; set; }

    public int IdRole { get; set; }

    public virtual RefEmployee IdEmployeeNavigation { get; set; } = null!;

    public virtual RefControlGroup IdGroupNavigation { get; set; } = null!;

    public virtual RefControlGroupRole IdRoleNavigation { get; set; } = null!;
}

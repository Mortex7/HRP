using System;
using System.Collections.Generic;

namespace HRP.Domain.Entities;

public partial class RefControlGroup
{
    public int IdGroup { get; set; }

    public string? GroupName { get; set; }

    public virtual ICollection<AppEmployeeControlGroupRole> AppEmployeeControlGroupRoles { get; set; } = new List<AppEmployeeControlGroupRole>();
}

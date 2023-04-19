using System;
using System.Collections.Generic;

namespace HRP.Domain.Entities;

public partial class RefControlGroupRole
{
    public int IdRole { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<AppEmployeeControlGroupRole> AppEmployeeControlGroupRoles { get; set; } = new List<AppEmployeeControlGroupRole>();
}

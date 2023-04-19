using System;
using System.Collections.Generic;

namespace HRP.Domain.Entities;

public partial class RefPosition
{
    public int IdPosition { get; set; }

    public string? PositionName { get; set; }

    public virtual ICollection<RefEmployee> RefEmployees { get; set; } = new List<RefEmployee>();
}

using System;
using System.Collections.Generic;

namespace HRP.Domain.Entities;

public partial class RefCategory
{
    public int IdCategory { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<RefEmployee> RefEmployees { get; set; } = new List<RefEmployee>();
}

using System;
using System.Collections.Generic;

namespace HRP.Domain.Entities;

public partial class RefSubdivision
{
    public int IdSubdivision { get; set; }

    public string? SubdivisionName { get; set; }

    public int? IdParentSubdivision { get; set; }

    public string? ShortName { get; set; }

    public virtual RefSubdivision? IdParentSubdivisionNavigation { get; set; }

    public virtual ICollection<RefSubdivision> InverseIdParentSubdivisionNavigation { get; set; } = new List<RefSubdivision>();

    public virtual ICollection<RefEmployee> RefEmployees { get; set; } = new List<RefEmployee>();
}

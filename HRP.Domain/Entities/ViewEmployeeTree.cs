using System;
using System.Collections.Generic;

namespace HRP.Domain.Entities;

public partial class ViewEmployeeTree
{
    public int IdEmployee { get; set; }

    public int? IdBoss { get; set; }

    public string? FullName { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? MiddleName { get; set; }

    public string EmployeeIdentificationNumber { get; set; } = null!;

    public string? DomainName { get; set; }

    public int IdPosition { get; set; }

    public string? PositionName { get; set; }

    public int IdSubdivision { get; set; }

    public string? SubdivisionName { get; set; }

    public int? IdParentSubdivision { get; set; }

    public string? ShortName { get; set; }

    public int IdCategory { get; set; }

    public string? CategoryName { get; set; }
}

using System;
using System.Collections.Generic;

namespace HRP.Domain.Entities;

public partial class RefEmployee
{
    public int IdEmployee { get; set; }

    public string Surname { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string MiddleName { get; set; } = null!;

    public int IdPosition { get; set; }
    public int IdSubdivision { get; set; }
    public int IdCategory { get; set; }

    public string EmployeeIdentificationNumber { get; set; } = null!;
    public string DomainName { get; set; } = null!;

    public virtual ICollection<AppEmployeeControlGroupRole> AppEmployeeControlGroupRoles { get; set; } = new List<AppEmployeeControlGroupRole>();
    public virtual ICollection<AppEmployeeHoliday> AppEmployeeHolidays { get; set; } = new List<AppEmployeeHoliday>();
    public virtual ICollection<AppEmployeeInProject> AppEmployeeInProjects { get; set; } = new List<AppEmployeeInProject>();
    public virtual ICollection<RefPlayer> RefPlayers { get; set; } = new List<RefPlayer>();

    public virtual RefCategory IdCategoryNavigation { get; set; } = null!;
    public virtual RefPosition IdPositionNavigation { get; set; } = null!;
    public virtual RefSubdivision IdSubdivisionNavigation { get; set; } = null!;
}

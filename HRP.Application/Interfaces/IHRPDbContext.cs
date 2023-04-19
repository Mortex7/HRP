using HRP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRP.Application.Interfaces;

public interface IHRPDbContext
{
    DbSet<AppEmployeeControlGroupRole> AppEmployeeControlGroupRoles { get; set; }
    DbSet<AppEmployeeHoliday> AppEmployeeHolidays { get; set; }
    DbSet<AppEmployeeInProject> AppEmployeeInProjects { get; set; }
    DbSet<AppHolidayInYear> AppHolidayInYears { get; set; }
    DbSet<RefCategory> RefCategories { get; set; }
    DbSet<RefControlGroup> RefControlGroups { get; set; }
    DbSet<RefControlGroupRole> RefControlGroupRoles { get; set; }
    DbSet<RefEmployee> RefEmployees { get; set; }
    DbSet<RefHoliday> RefHolidays { get; set; }
    DbSet<RefPlayer> RefPlayers { get; set; }
    DbSet<RefPosition> RefPositions { get; set; }
    DbSet<RefProject> RefProjects { get; set; }
    DbSet<RefSubdivision> RefSubdivisions { get; set; }
    DbSet<ViewEmployeeApprovement> ViewEmployeeApprovements { get; set; }
    DbSet<ViewEmployeeTree> ViewEmployeeTrees { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
using HRP.Application.Tools.Mapping;
using HRP.Domain.Entities;

namespace HRP.Application.ViewModels.Employee;

public class EmployeeVm : IMapWith<RefEmployee>
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
}
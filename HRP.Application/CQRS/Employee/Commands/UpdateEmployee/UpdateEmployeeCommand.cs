using MediatR;

namespace HRP.Application.CQRS.Employee.Commands.UpdateEmployee;

public class UpdateEmployeeCommand : IRequest
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
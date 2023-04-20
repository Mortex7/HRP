using MediatR;

namespace HRP.Application.CQRS.Employee.Commands.CreateEmployee;

public class CreateEmployeeCommand : IRequest<int>
{
    public string Surname { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public int IdPosition { get; set; }
    public int IdSubdivision { get; set; }
    public int IdCategory { get; set; }
    public string EmployeeIdentificationNumber { get; set; } = null!;
    public string DomainName { get; set; } = null!;
}
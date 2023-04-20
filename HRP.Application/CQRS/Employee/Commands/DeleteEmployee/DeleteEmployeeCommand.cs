using MediatR;

namespace HRP.Application.CQRS.Employee.Commands.DeleteEmployee;

public class DeleteEmployeeCommand : IRequest
{
    public int IdEmployee { get; set; }
}
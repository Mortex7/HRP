using HRP.Application.ViewModels.Employee;
using MediatR;

namespace HRP.Application.CQRS.Employee.Queries.GetEmployee;

public class GetEmployeeQuery : IRequest<EmployeeVm>
{
    public int IdEmployee { get; set; }
}
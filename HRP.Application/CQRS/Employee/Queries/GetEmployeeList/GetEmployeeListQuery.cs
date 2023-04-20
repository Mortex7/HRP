using HRP.Application.ViewModels.Employee;
using MediatR;

namespace HRP.Application.CQRS.Employee.Queries.GetEmployeeList;

public class GetEmployeeListQuery : IRequest<IList<EmployeeVm>>
{
    public IList<int> EmployeeIds { get; set; }
}
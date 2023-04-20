using AutoMapper;
using HRP.Application.Interfaces;
using HRP.Application.ViewModels.Employee;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRP.Application.CQRS.Employee.Queries.GetEmployeeList;

public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, IList<EmployeeVm>>
{
    private readonly IHRPDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetEmployeeListQueryHandler(IHRPDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IList<EmployeeVm>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
    {
        var employees = await _dbContext.RefEmployees
            .Where(employee => request.EmployeeIds.Contains(employee.IdEmployee) || request.EmployeeIds.Count == 0)
            .ToListAsync(cancellationToken);

        return _mapper.Map<IList<EmployeeVm>>(employees);
    }
}
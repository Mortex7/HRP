using AutoMapper;
using HRP.Application.Interfaces;
using HRP.Application.Tools.Exceptions;
using HRP.Application.ViewModels.Employee;
using HRP.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRP.Application.CQRS.Employee.Queries.GetEmployee;

public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, EmployeeVm>
{
    private readonly IHRPDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetEmployeeQueryHandler(IHRPDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<EmployeeVm> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employee = await _dbContext.RefEmployees.FirstOrDefaultAsync(employee => employee.IdEmployee == request.IdEmployee, cancellationToken);
        if (employee == null)
        {
            throw new EntityNotFoundException(nameof(RefEmployee), request.IdEmployee);
        }

        return _mapper.Map<EmployeeVm>(employee);
    }
}
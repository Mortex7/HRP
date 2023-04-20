using HRP.Application.Interfaces;
using HRP.Application.Tools.Exceptions;
using HRP.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRP.Application.CQRS.Employee.Commands.UpdateEmployee;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IHRPDbContext _dbContext;

    public UpdateEmployeeCommandHandler(IHRPDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _dbContext.RefEmployees.FirstOrDefaultAsync(employee => employee.IdEmployee == request.IdEmployee, cancellationToken);

        if (employee == null)
        {
            throw new EntityNotFoundException(nameof(RefEmployee), request.IdEmployee);
        }

        employee.Surname = request.Surname;
        employee.MiddleName = request.MiddleName;
        employee.IdPosition = request.IdPosition;
        employee.IdSubdivision = request.IdSubdivision;
        employee.IdCategory = request.IdCategory;
        employee.EmployeeIdentificationNumber = request.EmployeeIdentificationNumber;
        employee.DomainName = request.DomainName;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
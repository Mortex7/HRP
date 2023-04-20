using HRP.Application.Interfaces;
using HRP.Domain.Entities;
using MediatR;

namespace HRP.Application.CQRS.Employee.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IHRPDbContext _dbContext;

    public CreateEmployeeCommandHandler(IHRPDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new RefEmployee()
        {
            Surname = request.Surname,
            MiddleName = request.MiddleName,
            IdPosition = request.IdPosition,
            IdSubdivision = request.IdSubdivision,
            IdCategory = request.IdCategory,
            EmployeeIdentificationNumber = request.EmployeeIdentificationNumber,
            DomainName = request.DomainName
        };

        await _dbContext.RefEmployees.AddAsync(employee, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return employee.IdEmployee;
    }
}
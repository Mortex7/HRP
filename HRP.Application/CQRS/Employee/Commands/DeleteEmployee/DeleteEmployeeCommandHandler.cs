using HRP.Application.Interfaces;
using HRP.Application.Tools.Exceptions;
using HRP.Domain.Entities;
using MediatR;

namespace HRP.Application.CQRS.Employee.Commands.DeleteEmployee;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IHRPDbContext _dbContext;

    public DeleteEmployeeCommandHandler(IHRPDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _dbContext.RefEmployees.FindAsync(new[] { request.IdEmployee }, cancellationToken);

        if (employee == null)
        {
            throw new EntityNotFoundException(nameof(RefEmployee), request.IdEmployee);
        }

        _dbContext.RefEmployees.Remove(employee);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
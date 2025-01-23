using CQRSNight.Context;
using CQRSNight.MediatorDesignPattern.Commands;
using MediatR;

namespace CQRSNight.MediatorDesignPattern.Handlers;

public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommand>
{
    private readonly CQRSContext _context;

    public RemoveCustomerCommandHandler(CQRSContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
    {
        var value = await _context.Customers.FindAsync(request.CustomerId);
        _context.Customers.Remove(value);
        await _context.SaveChangesAsync();
    }
}

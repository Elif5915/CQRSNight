using CQRSNight.Context;
using CQRSNight.MediatorDesignPattern.Commands;
using MediatR;

namespace CQRSNight.MediatorDesignPattern.Handlers;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
{
    private readonly CQRSContext _context;

    public UpdateCustomerCommandHandler(CQRSContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var value = await _context.Customers.FindAsync(request.CustomerId);
        value.CustomerSurName = request.CustomerSurName;
        value.CustomerName = request.CustomerName;
        await _context.SaveChangesAsync();
    }
}

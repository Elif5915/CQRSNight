using CQRSNight.Context;
using CQRSNight.Entities;
using CQRSNight.MediatorDesignPattern.Commands;
using MediatR;

namespace CQRSNight.MediatorDesignPattern.Handlers;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly CQRSContext _context;

    public CreateCustomerCommandHandler(CQRSContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        _context.Customers.Add(new Customer
        {
            CustomerName = request.CustomerName,
            CustomerSurName = request.CustomerSurName
        });
        await _context.SaveChangesAsync();
    }
}

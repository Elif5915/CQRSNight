using CQRSNight.Context;
using CQRSNight.MediatorDesignPattern.Queries;
using CQRSNight.MediatorDesignPattern.Results;
using MediatR;

namespace CQRSNight.MediatorDesignPattern.Handlers;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdQueryResult>
{
    private readonly CQRSContext _context;

    public GetCustomerByIdQueryHandler(CQRSContext context)
    {
        _context = context;
    }

    public async Task<GetCustomerByIdQueryResult> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _context.Customers.FindAsync(request.CustomerId);
        return new GetCustomerByIdQueryResult
        {
            CustomerId = values.CustomerId,
            CustomerName = values.CustomerName,
            CustomerSurName = values.CustomerSurName
        };
    }
}

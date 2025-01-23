using CQRSNight.Context;
using CQRSNight.MediatorDesignPattern.Queries;
using CQRSNight.MediatorDesignPattern.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSNight.MediatorDesignPattern.Handlers;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, List<GetCustomerQueryResult>>
{
    private readonly CQRSContext _context;
    public GetCustomerQueryHandler(CQRSContext context)
    {
        _context = context;
    }

    public async Task<List<GetCustomerQueryResult>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var values = await _context.Customers.ToListAsync();
        return values.Select(x => new GetCustomerQueryResult
        {
            CustomerId = x.CustomerId,
            CustomerName = x.CustomerName,
            CustomerSurName = x.CustomerSurName

        }).ToList();


    }


}

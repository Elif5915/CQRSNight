using CQRSNight.MediatorDesignPattern.Results;
using MediatR;

namespace CQRSNight.MediatorDesignPattern.Queries;

public class GetCustomerByIdQuery : IRequest<GetCustomerByIdQueryResult>
{
    public int CustomerId { get; set; }

    public GetCustomerByIdQuery(int customerId)
    {
        CustomerId = customerId;
    }
}

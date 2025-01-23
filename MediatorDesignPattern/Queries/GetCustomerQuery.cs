using CQRSNight.MediatorDesignPattern.Results;
using MediatR;

namespace CQRSNight.MediatorDesignPattern.Queries;

public class GetCustomerQuery : IRequest<List<GetCustomerQueryResult>>
{

}

using MediatR;

namespace CQRSNight.MediatorDesignPattern.Commands;

public class RemoveCustomerCommand : IRequest
{
    public int CustomerId { get; set; }
    public RemoveCustomerCommand(int customerId)
    {
        CustomerId = customerId;
    }
}

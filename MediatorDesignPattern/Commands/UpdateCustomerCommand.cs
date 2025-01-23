using MediatR;

namespace CQRSNight.MediatorDesignPattern.Commands;

public class UpdateCustomerCommand : IRequest
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerSurName { get; set; }
}

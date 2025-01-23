namespace CQRSNight.MediatorDesignPattern.Results;

public class GetCustomerByIdQueryResult
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerSurName { get; set; }
}

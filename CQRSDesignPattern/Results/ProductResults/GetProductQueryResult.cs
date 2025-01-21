namespace CQRSNight.CQRSDesignPattern.Results.ProductResults;

public class GetProductQueryResult
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int ProductStock { get; set; }
    public decimal ProductPrice { get; set; }
}

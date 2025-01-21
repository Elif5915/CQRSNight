namespace CQRSNight.CQRSDesignPattern.Commands.ProductCommands;

public class CreateProductCommand
{
    public string ProductName { get; set; }
    public int ProductStock { get; set; }
    public decimal ProductPrice { get; set; }
}

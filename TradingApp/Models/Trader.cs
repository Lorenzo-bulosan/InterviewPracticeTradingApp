namespace TradingApp.Models;

public class Trader
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Desk { get; set; } = string.Empty;

    public decimal MaxOrderNotional { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();

    public ICollection<Trade> Trades { get; set; } = new List<Trade>();
}
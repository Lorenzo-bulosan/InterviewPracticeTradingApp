using TradingApp.Enums;

namespace TradingApp.Models;

public class Instrument
{
    public int Id { get; set; }

    public string Symbol { get; set; } = string.Empty;

    public AssetClassIds AssetClass { get; set; }

    public string Currency { get; set; } = string.Empty;

    public ICollection<Order> Orders { get; set; } = new List<Order>();

    public ICollection<Trade> Trades { get; set; } = new List<Trade>();

    public ICollection<MarketPrice> MarketPrices { get; set; } = new List<MarketPrice>();
}
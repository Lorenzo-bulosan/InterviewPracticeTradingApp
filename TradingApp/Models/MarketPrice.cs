namespace TradingApp.Models;

public class MarketPrice
{
    public int Id { get; set; }

    public int InstrumentId { get; set; }

    public decimal Price { get; set; }

    public DateTime Timestamp { get; set; }

    public Instrument Instrument { get; set; } = null!;
}
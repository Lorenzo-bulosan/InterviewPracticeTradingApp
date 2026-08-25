using System.Drawing;
using TradingApp.Enums;

namespace TradingApp.Models;

public class Trade
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int TraderId { get; set; }

    public int InstrumentId { get; set; }

    public SideIds Side { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public DateTime TradeTime { get; set; }

    public Order Order { get; set; } = null!;

    public Trader Trader { get; set; } = null!;

    public Instrument Instrument { get; set; } = null!;
}
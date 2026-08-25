using System.Drawing;
using TradingApp.Enums;

namespace TradingApp.Models;

public class Order
{
    public int Id { get; set; }

    public int TraderId { get; set; }

    public int InstrumentId { get; set; }

    public SideIds Side { get; set; }

    public decimal Quantity { get; set; }

    public decimal LimitPrice { get; set; }

    public OrderStatusIds Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public Trader Trader { get; set; } = null!;

    public Instrument Instrument { get; set; } = null!;

    public ICollection<Trade> Trades { get; set; } = new List<Trade>();
}
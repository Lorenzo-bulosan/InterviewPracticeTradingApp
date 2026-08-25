using Microsoft.EntityFrameworkCore;
using TradingApp.Data;
using TradingApp.Models;
using TradingApp.Enums;
using System.Reflection.Metadata.Ecma335;

namespace TradingApp.Services;

public class TradingService
{
    private readonly ILogger<TradingService> _logger;
    private readonly TradingDbContext _context;

    public TradingService(
        ILogger<TradingService> logger,
        TradingDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    // ============================================================
    // EXERCISE 1
    // Filtering
    // ============================================================

    // Already completed.
    //
    // Goal:
    // Understand that Where() can be translated into SQL.

    public List<Instrument> GetEquityInstruments()
    {
        return _context.Instruments
            .Where(i => i.AssetClass == AssetClassIds.Equity)
            .ToList();
    }


    // ============================================================
    // EXERCISE 2
    // Multiple Where conditions
    // ============================================================

    // ❌ BAD CODE
    //
    // Loads ALL instruments into memory and then filters them.
    //
    // Your task:
    // Make the filtering happen in SQL.

    public List<Instrument> GetUsdEquities()
    {
        var instruments = _context.Instruments.ToList();

        return instruments
            .Where(i => i.AssetClass == AssetClassIds.Equity)
            .Where(i => i.Currency == "USD")
            .ToList();
    }


    // ============================================================
    // EXERCISE 3
    // Projection
    // ============================================================

    // ❌ BAD CODE
    //
    // Loads complete Instrument entities into memory even though
    // we only need the symbols.
    //
    // Your task:
    // Make SQL return only the Symbol column.

    public List<string> GetEquitySymbols()
    {
        //var instruments = _context.Instruments
        //    .Where(i => i.AssetClass == AssetClassIds.Equity)
        //    .ToList();

        //return instruments
        //    .Select(i => i.Symbol)
        //    .ToList();

        var instruments = _context.Instruments;
        return instruments.Where(i => i.AssetClass == AssetClassIds.Equity).Select(i => i.Symbol).ToList();
    }


    // ============================================================
    // EXERCISE 4
    // Count
    // ============================================================

    // ❌ BAD CODE
    //
    // Loads every Trade into memory just to count them.
    //
    // Your task:
    // Make COUNT execute in SQL.

    public int GetTradeCount()
    {
        var trades = _context.Trades.Count();

        return trades;
    }


    // ============================================================
    // EXERCISE 5
    // GroupBy / Count
    // ============================================================

    // ❌ BAD CODE
    //
    // Loads every Trade into application memory before
    // performing the grouping.
    //
    // Your task:
    // Make GroupBy and Count execute in SQL.

    public async Task<object> GetTradeCountByTrader()
    {
        var trades = _context.Trades;

        return await trades
            .GroupBy(t => t.TraderId)
            .Select(g => new {
                TraderId = g.Key,
                TradeCount = g.Count() 
            })
            .ToListAsync();
    }


    // ============================================================
    // EXERCISE 6
    // GroupBy / Count by Instrument
    // ============================================================

    // ❌ BAD CODE
    //
    // Loads every Trade into memory.
    //
    // Your task:
    // Group trades by InstrumentId and count them in SQL.

    public object GetTradeCountByInstrument()
    {
        var trades = _context.Trades;

        var result = trades
            .GroupBy(t => t.InstrumentId)
            .Select(g => new
            {
                InstrumentId = g.Key,
                TradeCount = g.Count()
            });

        return result.ToList();
    }


    // ============================================================
    // EXERCISE 7
    // GroupBy / Sum
    // ============================================================

    // ❌ BAD CODE
    //
    // DO NOT use Notional here.
    //
    // Instead, use a numeric property that actually exists
    // on your Trade model.
    //
    // Your task:
    // Find a numeric Trade property and calculate its total
    // grouped by TraderId.
    //
    // Example concept:
    //
    // TraderId | TotalQuantity
    //
    // 1        | ...
    // 2        | ...
    // 3        | ...
    //
    // First write the BAD version using ToList().
    // Then remove ToList() so SUM happens in SQL.

    public async Task<object> GetTotalTradeValueByTraderAsync()
    {
        var trades = _context.Trades;

        return await trades
            .GroupBy(t => t.TraderId)
            .Select( g => new
            {
                TraderId = g.Key,
                TotalTradeValue = g.Sum(t => t.Quantity * t.Price)
            })
            .ToListAsync();
    }


    // ============================================================
    // EXERCISE 8
    // OrderBy
    // ============================================================

    // ❌ BAD CODE
    //
    // Loads all instruments and sorts them in memory.
    //
    // Your task:
    // Make ORDER BY execute in SQL.

    public List<Instrument> GetEquitiesOrderedBySymbol()
    {
        var instruments = _context.Instruments
            .Where(i => i.AssetClass == AssetClassIds.Equity);

        return instruments
            .OrderBy(i => i.Symbol)
            .ToList();
    }


    // ============================================================
    // EXERCISE 9
    // First / FirstOrDefault
    // ============================================================

    // ❌ BAD CODE
    //
    // Loads all instruments into memory just to find AAPL.
    //
    // Your task:
    // Make the database find the instrument.

    public Instrument? GetInstrument(string symbol)
    {
        var instruments = _context.Instruments;

        return instruments
            .FirstOrDefault(i => i.Symbol == symbol);
    }


    // ============================================================
    // EXERCISE 10
    // Filtering + Projection
    // ============================================================

    // ❌ BAD CODE
    //
    // Loads complete Instrument objects when the API only needs
    // Symbol and Currency.
    //
    // Your task:
    // Return only the required fields from SQL.

    public object GetEquityInstrumentSummary()
    {
        var instruments = _context.Instruments
            .Where(i => i.AssetClass == AssetClassIds.Equity);

        return instruments
            .Select(i => new
            {
                i.Symbol,
                i.Currency
            })
            .ToList();
    }


    // ============================================================
    // EXERCISE 11
    // Async
    // ============================================================

    // ❌ BAD CODE
    //
    // Uses synchronous database access inside an async method.
    //
    // Your task:
    // Replace the database operation with the appropriate
    // async EF Core method.

    public async Task<List<Trade>> GetAllTradesAsync()
    {
        var trades = await _context.Trades.ToListAsync();

        return trades;
    }


    // ============================================================
    // EXERCISE 12
    // Async + Filtering
    // ============================================================

    // ❌ BAD CODE
    //
    // Loads everything first.
    //
    // Your task:
    // Make the filtering AND database operation async.

    public async Task<List<Instrument>> GetFxInstrumentsAsync()
    {
        var instruments = _context.Instruments;

        return await instruments
            .Where(i => i.AssetClass == AssetClassIds.Fx)
            .ToListAsync();
    }


    // ============================================================
    // EXERCISE 13
    // Navigation Property / Join
    // ============================================================

    // ❌ BAD CODE
    //
    // Loads trades into memory before accessing related information.
    //
    // Goal:
    // Return trade information together with the trader's name.
    //
    // Think about:
    //
    // Trade
    //   -> Trader
    //
    // Your task:
    // Make EF perform the required SQL JOIN.

    public object GetTradesWithTraderName()
    {
        var trades = _context.Trades;

        return trades
            .Select(t => new
            {
                t.Id,
                t.TraderId,
                TraderName = t.Trader.Name
            })
            .ToList();
    }


    // ============================================================
    // EXERCISE 14
    // Navigation Property / Instrument
    // ============================================================

    // ❌ BAD CODE
    //
    // Loads all trades first.
    //
    // Your task:
    // Return:
    //
    // TradeId
    // Instrument Symbol
    // TraderId
    //
    // without loading all Trade entities into memory.

    public object GetTradeInstrumentSummary()
    {
        var trades = _context.Trades.ToList();

        return trades
            .Select(t => new
            {
                TradeId = t.Id,
                Symbol = t.Instrument.Symbol,
                TraderId = t.TraderId
            })
            .ToList();
    }


    // ============================================================
    // EXERCISE 15
    // Filtering through a relationship
    // ============================================================

    // ❌ BAD CODE
    //
    // Loads all trades and then checks the related instrument.
    //
    // Your task:
    // Return only trades for Equity instruments.
    //
    // The filtering should happen in SQL.

    public List<Trade> GetEquityTrades()
    {
        var trades = _context.Trades;

        return trades
            .Where(t => t.Instrument.AssetClass == AssetClassIds.Equity)
            .ToList();
    }


    // ============================================================
    // EXERCISE 16
    // Count with filtering
    // ============================================================

    // ❌ BAD CODE
    //
    // Loads all trades just to answer:
    // "How many trades does Alice have?"
    //
    // Your task:
    // Make the database perform the filtering and COUNT.

    public int GetTradeCountForTrader(int traderId)
    {
        var trades = _context.Trades;

        return trades
            .Where(t => t.TraderId == traderId)
            .Count();
    }


    // ============================================================
    // EXERCISE 17
    // GroupBy + relationship
    // ============================================================

    // ❌ BAD CODE
    //
    // Loads all trades and then groups them.
    //
    // Your task:
    // Return:
    //
    // TraderId
    // TraderName
    // TradeCount
    //
    // grouped by trader.
    //
    // This is a good exercise because it combines:
    //
    // Where / GroupBy / Count / Select
    // + navigation properties
    // + SQL translation

    public object GetTradeCountByTraderWithName()
    {
        var trades = _context.Trades.ToList();

        return trades
            .GroupBy(t => new
            {
                t.TraderId,
                TraderName = t.Trader.Name
            })
            .Select(g => new
            {
                TraderId = g.Key.TraderId,
                TraderName = g.Key.TraderName,
                TradeCount = g.Count()
            })
            .OrderByDescending(x => x.TradeCount)
            .ToList();
    }


    // ============================================================
    // EXERCISE 18
    // The important one: IQueryable vs IEnumerable
    // ============================================================

    // ❌ BAD CODE
    //
    // Something has caused the query to execute before the
    // filtering happens.
    //
    // Your task:
    // Make the entire operation one SQL query.
    //
    // Think carefully about where ToList() belongs.

    public List<string> GetUsdInstrumentSymbols()
    {
        var instruments = _context.Instruments;

        return instruments
            .Where(i => i.Currency == "USD")
            .Select(i => i.Symbol)
            .ToList();
    }


    // ============================================================
    // EXERCISE 19
    // Two database calls
    // ============================================================

    // ❌ BAD CODE
    //
    // This intentionally performs TWO database queries.
    //
    // Your task:
    // Think about whether both operations can be combined into
    // ONE database query.
    //
    // Requirement:
    // Return the number of equity instruments AND their symbols.
    //
    // First identify how many DB calls are happening.
    // Then decide whether one query can produce the result.

    public object GetEquityCountAndSymbols()
    {
        var count = _context.Instruments
            .Count(i => i.AssetClass == AssetClassIds.Equity);

        var symbols = _context.Instruments
            .Where(i => i.AssetClass == AssetClassIds.Equity)
            .Select(i => i.Symbol)
            .ToList();

        return new
        {
            Count = count,
            Symbols = symbols
        };
    }


    // ============================================================
    // EXERCISE 20
    // "I already loaded it, why does it query again?"
    // ============================================================

    // ❌ BAD CODE
    //
    // This is specifically designed to practise the concept
    // you were asking about earlier.
    //
    // The first ToList() executes a SQL query.
    //
    // The second query starts from _context.Trades again.
    //
    // Your task:
    // Understand whether the second operation uses the
    // in-memory list or causes another SQL query.
    //
    // Then rewrite it so you intentionally choose between:
    //
    //   A) two database calls
    //
    //   B) one database call
    //
    //   C) one database call followed by in-memory operations

    public object InvestigateMultipleQueries()
    {
        var trades = _context.Trades.ToList();

        var count = _context.Trades.Count();

        return new
        {
            LoadedTrades = trades.Count,
            DatabaseCount = count
        };
    }

    // ============================================================
    // EXERCISE 21
    // Change Tracking cost
    // ============================================================
    // ❌ BAD CODE (for a read-only endpoint)
    //
    // Every entity returned is tracked. EF keeps a snapshot of
    // original values even though you will never call SaveChanges.
    //
    // Your task:
    // Make this a pure read-only query.
    public List<Trade> GetAllTradesTracked()
    {
        return _context.Trades.AsNoTracking().ToList();   // tracking is on by default
    }

    // ============================================================
    // EXERCISE 22
    // AsNoTracking
    // ============================================================
    // Goal:
    // Same as above, but opt out of change tracking.
    //
    // Use this pattern for any API endpoint that only returns data.
    public List<Trade> GetAllTradesNoTracking()
    {
        return _context.Trades
            .AsNoTracking()
            .ToList();
    }

    // ============================================================
    // EXERCISE 23
    // Eager Loading – Include
    // ============================================================
    // ❌ BAD CODE – classic N+1 risk
    //
    // Loads trades only. Accessing .Trader or .Instrument later
    // will either fail (no lazy loading) or trigger extra queries.
    //
    // Your task:
    // Eager-load Trader and Instrument in one go.
    public List<Trade> GetTradesWithTraderAndInstrument()
    {
        // BAD:
        // return _context.Trades.ToList();

        return _context.Trades
            .Include(t => t.Trader)
            .Include(t => t.Instrument)
            .AsNoTracking()                 // good habit for read-only
            .ToList();
    }

    // ============================================================
    // EXERCISE 24
    // ThenInclude (nested)
    // ============================================================
    // Goal:
    // Load every Order together with its Trades and each Trade's Instrument.
    //
    // Chain:
    // Order → Trades → Instrument
    public List<Order> GetOrdersWithTradesAndInstruments()
    {
        return _context.Orders
            .Include(o => o.Trades)
                .ThenInclude(t => t.Instrument)
            .AsNoTracking()
            .ToList();
    }

    // ============================================================
    // EXERCISE 25
    // Explicit Loading
    // ============================================================
    // Goal:
    // First load a single Trader.
    // Then, only if needed, explicitly load their Trades.
    //
    // This is useful when the related data is conditional.
    public async Task<object> GetTraderAndMaybeTradesAsync(int traderId, bool includeTrades)
    {
        var trader = await _context.Traders
            .FirstOrDefaultAsync(t => t.Id == traderId);

        if (trader is null)
            return null;

        if (includeTrades)
        {
            // Explicit load – you control when the second query fires
            await _context.Entry(trader)
                .Collection(t => t.Trades)
                .LoadAsync();
        }

        return new
        {
            trader.Id,
            trader.Name,
            TradeCount = trader.Trades?.Count ?? 0
        };
    }

    // ============================================================
    // EXERCISE 26
    // The N+1 problem (spot the bug)
    // ============================================================
    // ❌ BAD CODE – classic interview question
    //
    // One query for the trades, then one extra query PER trade
    // when the loop touches the navigation property.
    //
    // Your task:
    // 1. Understand why this is N+1.
    // 2. Fix it with a single Include (or projection).
    public List<string> GetTradeSummariesNPlusOne()
    {
        var trades = _context.Trades.ToList();   // query 1

        var result = new List<string>();
        foreach (var trade in trades)
        {
            // If lazy loading is enabled this fires a query every iteration
            // If lazy loading is disabled this throws
            result.Add($"{trade.Id}: {trade.Trader.Name} – {trade.Instrument.Symbol}");
        }
        return result;
    }

    // ============================================================
    // EXERCISE 27
    // Fixed N+1 with Include
    // ============================================================
    // Goal:
    // Same result as Exercise 26, but with 1 (or 2) database round-trips total.
    public List<string> GetTradeSummariesFixed()
    {
        var trades = _context.Trades
            .Include(t => t.Trader)
            .Include(t => t.Instrument)
            .AsNoTracking()
            .ToList();

        return trades
            .Select(t => $"{t.Id}: {t.Trader.Name} – {t.Instrument.Symbol}")
            .ToList();
    }

    // ============================================================
    // EXERCISE 28
    // Fixed N+1 with Projection (often better)
    // ============================================================
    // Goal:
    // Avoid loading full entities at all.
    // Project only the columns you need – no tracking, no over-fetching.
    public List<string> GetTradeSummariesProjected()
    {
        return _context.Trades
            .AsNoTracking()
            .Select(t => $"{t.Id}: {t.Trader.Name} – {t.Instrument.Symbol}")
            .ToList();
    }

    // ============================================================
    // EXERCISE 29
    // Simple Transaction
    // ============================================================
    // Goal:
    // Place two related changes inside a transaction.
    // If either fails, both are rolled back.
    //
    // Scenario: create a new Order and a related Trade atomically.
    public async Task PlaceOrderAndTradeAsync(int traderId, int instrumentId, decimal quantity, decimal price)
    {

        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                // Create and add order
                var newOrder = new Order
                {
                    TraderId = traderId,
                    InstrumentId = instrumentId,
                    Quantity = quantity,
                };

                _context.Orders.Add(newOrder);

                // Create and add Trade
                var Trade = new Trade
                {
                    TraderId = traderId,
                    InstrumentId = instrumentId,
                    OrderId = newOrder.Id,
                    Quantity = quantity,
                    Price = price
                };

                _context.Trades.Add(Trade);

                // Save changes
                await _context.SaveChangesAsync();

                // Commit
                await _context.Database.CommitTransactionAsync();
            }
            catch
            {
                _context.Database.RollbackTransaction();
                throw;
            }
        }


        //await using var transaction = await _context.Database.BeginTransactionAsync();

        //try
        //{
        //    var order = new Order
        //    {
        //        TraderId = traderId,
        //        InstrumentId = instrumentId
        //        // set other required properties as needed
        //    };
        //    _context.Orders.Add(order);
        //    await _context.SaveChangesAsync();   // order gets its Id

        //    var trade = new Trade
        //    {
        //        TraderId = traderId,
        //        InstrumentId = instrumentId,
        //        OrderId = order.Id,
        //        Quantity = quantity,
        //        Price = price
        //    };
        //    _context.Trades.Add(trade);
        //    await _context.SaveChangesAsync();

        //    await transaction.CommitAsync();
        //}
        //catch
        //{
        //    await transaction.RollbackAsync();
        //    throw;
        //}
    }

    // ============================================================
    // EXERCISE 30
    // Transaction + multiple operations + logging
    // ============================================================
    // Goal:
    // Demonstrate that DbContext is the unit-of-work.
    // All changes are tracked and then sent together (or rolled back).
    //
    // Also practise the pattern of catching, logging, and rethrowing.
    public async Task TransferNotionalLimitAsync(int fromTraderId, int toTraderId, decimal amount)
    {
        await using var tx = await _context.Database.BeginTransactionAsync();

        try
        {
            var from = await _context.Traders.FirstAsync(t => t.Id == fromTraderId);
            var to = await _context.Traders.FirstAsync(t => t.Id == toTraderId);

            if (from.MaxOrderNotional < amount)
                throw new InvalidOperationException("Insufficient notional limit");

            from.MaxOrderNotional -= amount;
            to.MaxOrderNotional += amount;

            await _context.SaveChangesAsync();   // both updates in one round-trip
            await tx.CommitAsync();

            _logger.LogInformation(
                "Transferred {Amount} notional from trader {From} to trader {To}",
                amount, fromTraderId, toTraderId);
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            _logger.LogError(ex, "Notional transfer failed");
            throw;
        }
    }
}
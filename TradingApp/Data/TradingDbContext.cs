using Microsoft.EntityFrameworkCore;
using TradingApp.Models;
using TradingApp.Enums;

namespace TradingApp.Data;

public class TradingDbContext : DbContext
{
    public TradingDbContext(DbContextOptions<TradingDbContext> options)
        : base(options)
    {
    }

    public DbSet<Trader> Traders => Set<Trader>();
    public DbSet<Instrument> Instruments => Set<Instrument>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Trade> Trades => Set<Trade>();
    public DbSet<MarketPrice> MarketPrices => Set<MarketPrice>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Trader>()
            .HasMany(t => t.Orders)
            .WithOne(o => o.Trader)
            .HasForeignKey(o => o.TraderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Trader>()
            .HasMany(t => t.Trades)
            .WithOne(t => t.Trader)
            .HasForeignKey(t => t.TraderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Instrument>()
            .HasMany(i => i.Orders)
            .WithOne(o => o.Instrument)
            .HasForeignKey(o => o.InstrumentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Instrument>()
            .HasMany(i => i.Trades)
            .WithOne(t => t.Instrument)
            .HasForeignKey(t => t.InstrumentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Instrument>()
            .HasMany(i => i.MarketPrices)
            .WithOne(mp => mp.Instrument)
            .HasForeignKey(mp => mp.InstrumentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.Trades)
            .WithOne(t => t.Order)
            .HasForeignKey(t => t.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Trader>().HasData(
            new Trader
            {
                Id = 1,
                Name = "Alice",
                Desk = "Equity",
                MaxOrderNotional = 1_000_000m
            },
            new Trader
            {
                Id = 2,
                Name = "Bob",
                Desk = "FX",
                MaxOrderNotional = 5_000_000m
            },
            new Trader
            {
                Id = 3,
                Name = "Charlie",
                Desk = "Equity",
                MaxOrderNotional = 2_000_000m
            }
        );
        modelBuilder.Entity<Instrument>().HasData(
            new Instrument
            {
                Id = 1,
                Symbol = "AAPL",
                AssetClass = AssetClassIds.Equity,
                Currency = "USD"
            },
            new Instrument
            {
                Id = 2,
                Symbol = "MSFT",
                AssetClass = AssetClassIds.Equity,
                Currency = "USD"
            },
            new Instrument
            {
                Id = 3,
                Symbol = "EURUSD",
                AssetClass = AssetClassIds.Fx,
                Currency = "EUR"
            },
            new Instrument
            {
                Id = 4,
                Symbol = "GBPUSD",
                AssetClass = AssetClassIds.Fx,
                Currency = "GBP"
            }
        );
        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                Id = 1,
                TraderId = 1,
                InstrumentId = 1, // AAPL
                                  // Add your actual Order properties here
            },
            new Order
            {
                Id = 2,
                TraderId = 1,
                InstrumentId = 2, // MSFT
            },
            new Order
            {
                Id = 3,
                TraderId = 2,
                InstrumentId = 3, // EURUSD
            },
            new Order
            {
                Id = 4,
                TraderId = 2,
                InstrumentId = 4, // GBPUSD
            },
            new Order
            {
                Id = 5,
                TraderId = 3,
                InstrumentId = 1, // AAPL
            },
            new Order
            {
                Id = 6,
                TraderId = 3,
                InstrumentId = 2, // MSFT
            }
        );
        modelBuilder.Entity<Trade>().HasData(
            new Trade
            {
                Id = 1,
                TraderId = 1,
                InstrumentId = 1,
                OrderId = 1,
                // Add your actual Trade properties
            },
            new Trade
            {
                Id = 2,
                TraderId = 1,
                InstrumentId = 1,
                OrderId = 1,
            },
            new Trade
            {
                Id = 3,
                TraderId = 1,
                InstrumentId = 2,
                OrderId = 2,
            },

            new Trade
            {
                Id = 4,
                TraderId = 2,
                InstrumentId = 3,
                OrderId = 3,
            },
            new Trade
            {
                Id = 5,
                TraderId = 2,
                InstrumentId = 3,
                OrderId = 3,
            },
            new Trade
            {
                Id = 6,
                TraderId = 2,
                InstrumentId = 4,
                OrderId = 4,
            },
            new Trade
            {
                Id = 7,
                TraderId = 2,
                InstrumentId = 4,
                OrderId = 4,
            },
            new Trade
            {
                Id = 8,
                TraderId = 2,
                InstrumentId = 4,
                OrderId = 4,
            },

            new Trade
            {
                Id = 9,
                TraderId = 3,
                InstrumentId = 1,
                OrderId = 5,
            },
            new Trade
            {
                Id = 10,
                TraderId = 3,
                InstrumentId = 2,
                OrderId = 6,
            },
            new Trade
            {
                Id = 11,
                TraderId = 3,
                InstrumentId = 2,
                OrderId = 6,
            }
        );
    }
}
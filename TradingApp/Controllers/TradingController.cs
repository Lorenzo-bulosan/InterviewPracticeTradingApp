using Microsoft.AspNetCore.Mvc;
using TradingApp.Models;
using TradingApp.Services;

namespace TradingApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TradingController : ControllerBase
{
    private readonly TradingService _tradingService;

    public TradingController(TradingService tradingService)
    {
        _tradingService = tradingService;
    }

    [HttpGet("GetAllTrades")]
    public async Task<ActionResult<List<Trade>>> GetAllTrades()
    {
        var trades = await _tradingService.GetAllTradesAsync();

        return Ok(trades);
    }

    [HttpGet("GetTradeCountByTrader")]
    public async Task<ActionResult<object>> GetTradeCountByTrader()
    {
        var tradeCountByTrader = await _tradingService.GetTradeCountByTrader();

        return Ok(tradeCountByTrader);
    }

    [HttpGet("GetEquitySymbols")]
    public ActionResult GetEquitySymbols()
    {
        var result = _tradingService.GetEquitySymbols();
        return Ok(result);
    }

    [HttpGet("GetTotalTradeValueByTrader")]
    public async Task<ActionResult> GetTotalTradeValueByTrader()
    {
        var result = await _tradingService.GetTotalTradeValueByTraderAsync();
        return Ok(result);
    }
}
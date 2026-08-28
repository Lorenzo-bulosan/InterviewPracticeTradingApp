/*
JOINs
List every order with the trader's name and the instrument symbol.
Show all trades with trader name, instrument symbol, and order status — including trades where the order might be missing (LEFT JOIN scenario).
Find all instruments that have never had an order placed on them (use a LEFT JOIN + IS NULL).
List each trader alongside the number of distinct instruments they've traded (JOIN Trades → Instruments, dedupe).
Show orders together with their most recent market price for that instrument (JOIN Orders to a subquery/latest MarketPrice per Instrument).
*/

-- List every order with the trader's name and the instrument symbol.
select 
	 o.*,
	 t.Name as TraderName,
	 i.Symbol
from Orders o
join Traders t on t.id = o.TraderId
join Instruments i on i.Id=o.instrumentId

-- Show all trades with trader name, instrument symbol, and order status — including trades where the order might be missing
select 
	t.*,
	tr.Name,
	i.Symbol,
	o.Status
from Trades t
join Traders tr on tr.Id = t.TraderId
left join Orders o on o.id = t.OrderId /* Intent, but you can also just do trades directly, trade can have missing order*/
join Instruments i on i.Id=t.instrumentId


/* Find all instruments that have never had an order placed on them */
select 
	i.*
from Instruments i
left join Orders o on o.InstrumentId = i.Id
where o.id is NULL -- instrument with no orders, but can't have nulls if inner join, has to be left/right join. Full outer would've also worked


/* List each trader alongside the number of distinct instruments they've traded  */
select
	tr.Id, tr.Name, -- These will have to be in group by as they are not being counted, we want to collapse these
	count (distinct i.Id) as InstrumentCount -- This is already wraped in aggregate so no need to be on group by
from Trades t
join Instruments i on i.Id = t.InstrumentId
join Traders tr on tr.Id = t.TraderId
group by tr.Id, tr.Name -- collapses into one row per trader. 


/*
WHERE
Find all orders placed by traders on the "Equity" desk.
Find all trades on FX instruments (currency = 'EUR' or 'GBP').
List traders whose MaxOrderNotional is between 1,000,000 and 3,000,000.
Find all orders where Status is 'Cancelled' or 'Rejected'.
Find instruments whose Symbol starts with 'A' or ends with 'USD'.
*/

-- Find all orders placed by traders on the "Equity" desk.
DECLARE @desk VARCHAR(20) = 'Equity'

select 
	o.*,
	t.Name, t.Desk
from Orders o
join Traders t on t.Id = o.TraderId
where t.Desk = @desk

-- Find all trades on FX instruments (currency = 'EUR' or 'GBP').
select 
	t.*,
	i.AssetClass
from Trades t
join Instruments i on i.Id = t.InstrumentId
where i.AssetClass = 1

-- List traders whose MaxOrderNotional is between 1,000,000 and 3,000,000.
select * from Traders
where MaxOrderNotional between 1000000 and 3000000

-- Find instruments whose Symbol starts with 'A' or ends with 'USD'.
select * from Instruments
where 
Symbol like 'A%' 
or Symbol like '%USD'


/*
GROUP BY / HAVING
Count the number of trades per trader.
Count the number of orders per instrument, showing only instruments with more than 1 order.
Find traders who have executed more than 3 trades total (HAVING COUNT > 3).
For each instrument, compute total traded quantity and average trade price; show only instruments with total quantity > some threshold.
Find desks (group by Trader.Desk) where the combined MaxOrderNotional exceeds 3,000,000.


INSERT
Insert a new trader "Dana" on the "Crypto" desk with a MaxOrderNotional of 750,000.
Insert a new instrument "BTCUSD" with AssetClass and Currency.
Insert a new order for trader "Dana" on "BTCUSD", then insert a matching trade against it (two INSERTs, using the generated OrderId).
Use INSERT INTO ... SELECT to copy all Equity-desk traders into an (imaginary) ArchivedTraders table.


UPDATE
Give every trader on the "Equity" desk a 10% increase to MaxOrderNotional.
Update the Status of all orders that have at least one matching Trade to 'Filled'.
Update an instrument's Currency using a CASE expression based on AssetClass.
Update Trader.MaxOrderNotional for trader "Bob" only if his current trade count exceeds 5 (subquery in WHERE).


DELETE
Delete all trades belonging to orders with Status = 'Cancelled'.
Delete traders who have never placed an order (careful with FK constraints — think about order of operations).
Delete duplicate trades that share the same OrderId, InstrumentId, and TraderId, keeping only the lowest Id (classic dedup exercise — good self-join or window function practice).


COALESCE / NULL handling
List all orders showing Price, but display 0 if Price is NULL (COALESCE(Price, 0)).
List traders with their trade count, showing 0 instead of NULL for traders with no trades (LEFT JOIN + COALESCE + COUNT).
Build a report column EffectiveNotional = COALESCE(Order.Price, MarketPrice.Price, 0) * Order.Quantity.
Subqueries / Correlated queries
Find traders whose average trade price is higher than the overall average trade price across all trades.
For each instrument, find the single most recent trade (correlated subquery or window function).
Find orders where the order's Price differs from the latest MarketPrice for that instrument by more than 1%.


Transactions
Write a transaction that inserts a new Order and a corresponding Trade, rolling back if the Trader's MaxOrderNotional would be exceeded (use BEGIN TRAN / COMMIT / ROLLBACK with a check).
Write a transaction that updates an order's status to 'Cancelled' and deletes any pending (unfilled) trades tied to it, ensuring both happen atomically.
Simulate a "trade booking" transaction: insert into Trades, update Order.Status, and if anything fails, ROLLBACK — wrap in TRY/CATCH (T-SQL) or equivalent.


Bonus: Window functions / CTEs
Rank trades per trader by ExecutedAt using ROW_NUMBER() OVER (PARTITION BY TraderId ORDER BY ExecutedAt DESC) and pull each trader's latest trade.
Use a CTE to compute running total traded quantity per instrument over time.
Compute each trader's rank by total notional traded using RANK() OVER (ORDER BY SUM(Quantity*Price) DESC).

*/

-- Find traders who have executed more than 3 trades total 

select
	t.Name, -- not grouped so needs to be grouped by
	count(tr.Id) as TradesMade -- group aggregated by count
from Traders t
join Trades tr on tr.TraderId = t.Id
group by t.Name
having count(tr.Id) > 3 -- filter on the group. Where filters per row not group

-- Find desks (group by Trader.Desk) where the combined MaxOrderNotional exceeds 3,000,000.
select
	Desk,
	SUM(MaxOrderNotional)
from Traders
group by Desk
having SUM(MaxOrderNotional) > 3000000

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exus.AlphaVantage;
using Exus.AlphaVantage.QueryResults;
using Microsoft.AspNetCore.Mvc;
using dll461;

namespace WebExus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymbolsController : ControllerBase
    {
        private static IApiQuerier _apiQuerier; //Injected

        public SymbolsController()
        {
            //theoretical thread contention hazard, but the production version would use dependency injection
            //factory design pattern, so OK in prototype
            if (_apiQuerier == null)
                _apiQuerier = new ApiQuerier("Z9770ZIXU68OT1UW");
        }

        // GET api/Symbols
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            IList<string> prices = new List<string>();


            // Intraday time series for MSFT:
            var result = GetIntradayTimeSeries("MSFT");
            var realResult = result.GetAwaiter().GetResult();
            // result.TimeSeries is a dictionary with the date time as the key
            foreach (var point in realResult.TimeSeries)
            {
                Console.WriteLine($"{point.Key}: {point.Value.Open}");
                prices.Add($"{point.Key}: {point.Value.Open}");
            }
            return prices.ToArray();
        }

        public async Task<TimeSeriesWeeklyAdjustedQueryResult> GetIntradayTimeSeries(string symbol)
        {
            var query = new Exus.AlphaVantage.Queries.TimeSeriesWeeklyAdjustedQuery
            {
                Symbol = symbol
            };

            var result = await _apiQuerier.Query(query);

            return result;
        }

        public async Task<TimeSeriesMonthlyAdjustedQueryResult> GetMonthlyAdjustedTimeSeries(string symbol)
        {
            var query = new Exus.AlphaVantage.Queries.TimeSeriesMonthlyAdjustedQuery
            {
                Symbol = symbol
            };

            var result = await _apiQuerier.Query(query);

            return result;
        }

        // GET api/Symbols/MSFTsymbol=MSFT&interval=5min&outputsize=full&apikey=demo
        [HttpGet("{symbol}")]
        public ActionResult<IEnumerable<string>> Get(string symbol)
        {
            //, [FromBody]string interval, [FromBody]string outputsize
            IList<string> prices = new List<string>();
//            int id = Persistence.SaveMetaData("Daily (60min)", symbol, DateTime.Now, "60min", "Full", "US/Eastern");
            // Intraday time series for MSFT:
            var result = GetIntradayTimeSeries("MSFT");
            var realResult = result.GetAwaiter().GetResult();
            // result.TimeSeries is a dictionary with the date time as the key
            foreach (var point in realResult.TimeSeries)
            {
                Console.WriteLine($"{point.Key}: {point.Value.Open}");
                prices.Add($"{point.Key}: {point.Value.Open}");
                //Persistence.SaveTimeSeries(id, Convert.ToDateTime(point.Key),
                //    Convert.ToDecimal(point.Value.Open),
                //    Convert.ToDecimal(point.Value.High),
                //    Convert.ToDecimal(point.Value.Low),
                //    Convert.ToDecimal(point.Value.Close),
                //    point.Value.Volume);
            }
            return prices.ToArray();

            //return "value for " + symbol;
        }

        // POST api/Symbols
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Symbols/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Symbols/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

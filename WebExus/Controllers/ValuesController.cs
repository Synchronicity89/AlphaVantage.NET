using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exus.AlphaVantage;
using Exus.AlphaVantage.QueryResults;
using Microsoft.AspNetCore.Mvc;

namespace WebExus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IApiQuerier _apiQuerier; //Injected

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            IList<string> prices = new List<string>();
            if(_apiQuerier == null)
                _apiQuerier = new ApiQuerier("Z9770ZIXU68OT1UW");

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

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value for " + id;
        }

        [HttpGet("{symbol}")]
        public ActionResult<string> Get(string symbol)
        {
            return "value for " + symbol;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

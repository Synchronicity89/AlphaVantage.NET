using Exus.AlphaVantage;
using Exus.AlphaVantage.Deserializer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace WebExus
{
    public class MyCustomApiWebClient : IApiWebClient
    {
        public const string QUERY_URL = "https://www.alphavantage.co/query";

        private readonly IApiQueryResultDeserializer<string> _deserializer;

        public MyCustomApiWebClient()
        {
            _deserializer = (IApiQueryResultDeserializer<string>)new ApiQueryResultDeserializer();
        }

        public MyCustomApiWebClient(IApiQueryResultDeserializer<string> deserializer)
        {
            _deserializer = deserializer;
        }

        public async Task<TApiQueryResult> Query<TApiQueryResult>(IApiQuery<TApiQueryResult> query)
        {
            using (var webClient = new System.Net.WebClient())
            {
                webClient.QueryString = query.Parameters.Aggregate(new NameValueCollection(),
                            (seed, current) => {
                                seed.Add(current.Key, current.Value);
                                return seed;
                            });
                var json = await webClient.DownloadStringTaskAsync(QUERY_URL);
                return _deserializer.Deserialize<TApiQueryResult>(json);
            }
        }
    }
}

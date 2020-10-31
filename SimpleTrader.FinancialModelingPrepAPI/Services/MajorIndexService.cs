using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType majorIndexType)
        {
            string uri = "https://financialmodelingprep.com/api/v3/quote/" + GetUriSuffix(majorIndexType);
            string apiKey = "c5a2e53fae0669e13e1bc53f1a1a6f27";

            using (var httpClient = new FinancialModelingPrepHttpClient())
            {
                MajorIndex majorIndex = await httpClient.GetAsync<MajorIndex>($"{uri}?apikey={apiKey}");

                if (majorIndex == null)
                    throw new Exception("API returned no results.");

                majorIndex.Type = majorIndexType;
                return majorIndex;

            }
        }

        private string GetUriSuffix(MajorIndexType majorIndexType)
        {
            return majorIndexType switch
            {
                MajorIndexType.DowJones => "^DJI",
                MajorIndexType.Nasdaq => "^IXIC",
                MajorIndexType.SP500 => "^GSPC",
                _ => throw new Exception("Major Index Type does not have a suffix defined"),
            };
        }
    }
}

using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services
{
    public interface IMajorIndexService
    {
        //https://financialmodelingprep.com/developer/docs/indexes-in-stock-market-free-api/#JSON
        Task<MajorIndex> GetMajorIndex(MajorIndexType majorIndexType);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polygon.Net
{
    public interface IPolygonClient
    {
        public Task<TickerInfo> GetTickerDetailsAsync(string ticker, string date);

        public Task<List<TickerInfo>> GetTickersAsync(string ticker);
    }
}
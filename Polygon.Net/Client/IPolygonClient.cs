using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polygon.Net
{
    public interface IPolygonClient
    {
        public Task<TickerDetailsInfo> GetTickerDetailsAsync(string ticker, string date);

        public Task<List<TickerInfo>> GetTickersAsync(string ticker);

        public Task<List<ExchangeInfo>> GetExchangesAsync();
    }
}
﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polygon.Net
{
    public interface IPolygonClient
    {
        public Task<PolygonResponse<List<TickerInfo>>> GetTickersAsync(
            string ticker = null,
            string tickerlt = null,
            string tickerlte = null,
            string tickergt = null,
            string tickergte = null,
            string type = null,
            string market = null,
            string exchange = null,
            string cusip = null,
            string date = null,
            bool? active = null,
            string sort = null,
            string order = null,
            int? limit = null,
            string nextUrl = null);

        public Task<PolygonResponse<TickerDetailsInfo>> GetTickerDetailsAsync(string ticker, string date);

        public Task<List<ExchangeInfo>> GetStockExchangesAsync();

        public Task<PolygonResponse<List<StockFinancialInfo>>> GetStockFinancialsAsync(
            string stocksTicker,
            string type = null,
            string sort = null,
            int? limit = null,
            string nextUrl = null);
    }
}
using Newtonsoft.Json;
using System;

namespace Polygon.Net
{
    public class StockFinancialInfo
    {
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("calendarDate")]
        public DateTime CalendarDate { get; set; }

        [JsonProperty("reportPeriod")]
        public DateTime ReportPeriod { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("accumulatedOtherComprehensiveIncome")]
        public long AccumulatedOtherComprehensiveIncome { get; set; }

        [JsonProperty("assets")]
        public long Assets { get; set; }

        [JsonProperty("assetsAverage")]
        public long AssetsAverage { get; set; }

        [JsonProperty("assetsCurrent")]
        public long AssetsCurrent { get; set; }

        [JsonProperty("assetTurnover")]
        public long AssetTurnover { get; set; }

        [JsonProperty("assetsNonCurrent")]
        public long AssetsNonCurrent { get; set; }

        [JsonProperty("bookValuePerShare")]
        public long BookValuePerShare { get; set; }

        [JsonProperty("capitalExpenditure")]
        public long CapitalExpenditure { get; set; }

        [JsonProperty("cashAndEquivalents")]
        public long CashAndEquivalents { get; set; }

        [JsonProperty("cashAndEquivalentsUSD")]
        public long CashAndEquivalentsUsd { get; set; }

        [JsonProperty("costOfRevenue")]
        public long CostOfRevenue { get; set; }

        [JsonProperty("consolidatedIncome")]
        public long ConsolidatedIncome { get; set; }

        [JsonProperty("currentRatio")]
        public long CurrentRatio { get; set; }

        [JsonProperty("debtToEquityRatio")]
        public long DebtToEquityRatio { get; set; }

        [JsonProperty("debt")]
        public long Debt { get; set; }

        [JsonProperty("debtCurrent")]
        public long DebtCurrent { get; set; }

        [JsonProperty("debtNonCurrent")]
        public long DebtNonCurrent { get; set; }

        [JsonProperty("debtUSD")]
        public long DebtUsd { get; set; }

        [JsonProperty("deferredRevenue")]
        public long DeferredRevenue { get; set; }

        [JsonProperty("depreciationAmortizationAndAccretion")]
        public long DepreciationAmortizationAndAccretion { get; set; }

        [JsonProperty("deposits")]
        public long Deposits { get; set; }

        [JsonProperty("dividendYield")]
        public long DividendYield { get; set; }

        [JsonProperty("dividendsPerBasicCommonShare")]
        public long DividendsPerBasicCommonShare { get; set; }

        [JsonProperty("earningBeforeInterestTaxes")]
        public long EarningBeforeInterestTaxes { get; set; }

        [JsonProperty("earningsBeforeInterestTaxesDepreciationAmortization")]
        public long EarningsBeforeInterestTaxesDepreciationAmortization { get; set; }

        [JsonProperty("EBITDAMargin")]
        public long EbitdaMargin { get; set; }

        [JsonProperty("earningsBeforeInterestTaxesDepreciationAmortizationUSD")]
        public long EarningsBeforeInterestTaxesDepreciationAmortizationUsd { get; set; }

        [JsonProperty("earningBeforeInterestTaxesUSD")]
        public long EarningBeforeInterestTaxesUsd { get; set; }

        [JsonProperty("earningsBeforeTax")]
        public long EarningsBeforeTax { get; set; }

        [JsonProperty("earningsPerBasicShare")]
        public long EarningsPerBasicShare { get; set; }

        [JsonProperty("earningsPerDilutedShare")]
        public long EarningsPerDilutedShare { get; set; }

        [JsonProperty("earningsPerBasicShareUSD")]
        public long EarningsPerBasicShareUsd { get; set; }

        [JsonProperty("shareholdersEquity")]
        public long ShareholdersEquity { get; set; }

        [JsonProperty("averageEquity")]
        public long AverageEquity { get; set; }

        [JsonProperty("shareholdersEquityUSD")]
        public long ShareholdersEquityUsd { get; set; }

        [JsonProperty("enterpriseValue")]
        public long EnterpriseValue { get; set; }

        [JsonProperty("enterpriseValueOverEBIT")]
        public long EnterpriseValueOverEbit { get; set; }

        [JsonProperty("enterpriseValueOverEBITDA")]
        public long EnterpriseValueOverEbitda { get; set; }

        [JsonProperty("freeCashFlow")]
        public long FreeCashFlow { get; set; }

        [JsonProperty("freeCashFlowPerShare")]
        public long FreeCashFlowPerShare { get; set; }

        [JsonProperty("foreignCurrencyUSDExchangeRate")]
        public long ForeignCurrencyUsdExchangeRate { get; set; }

        [JsonProperty("grossProfit")]
        public long GrossProfit { get; set; }

        [JsonProperty("grossMargin")]
        public long GrossMargin { get; set; }

        [JsonProperty("goodwillAndIntangibleAssets")]
        public long GoodwillAndIntangibleAssets { get; set; }

        [JsonProperty("interestExpense")]
        public long InterestExpense { get; set; }

        [JsonProperty("investedCapital")]
        public long InvestedCapital { get; set; }

        [JsonProperty("investedCapitalAverage")]
        public long InvestedCapitalAverage { get; set; }

        [JsonProperty("inventory")]
        public long Inventory { get; set; }

        [JsonProperty("investments")]
        public long Investments { get; set; }

        [JsonProperty("investmentsCurrent")]
        public long InvestmentsCurrent { get; set; }

        [JsonProperty("investmentsNonCurrent")]
        public long InvestmentsNonCurrent { get; set; }

        [JsonProperty("totalLiabilities")]
        public long TotalLiabilities { get; set; }

        [JsonProperty("currentLiabilities")]
        public long CurrentLiabilities { get; set; }

        [JsonProperty("liabilitiesNonCurrent")]
        public long LiabilitiesNonCurrent { get; set; }

        [JsonProperty("marketCapitalization")]
        public long MarketCapitalization { get; set; }

        [JsonProperty("netCashFlow")]
        public long NetCashFlow { get; set; }

        [JsonProperty("netCashFlowBusinessAcquisitionsDisposals")]
        public long NetCashFlowBusinessAcquisitionsDisposals { get; set; }

        [JsonProperty("issuanceEquityShares")]
        public long IssuanceEquityShares { get; set; }

        [JsonProperty("issuanceDebtSecurities")]
        public long IssuanceDebtSecurities { get; set; }

        [JsonProperty("paymentDividendsOtherCashDistributions")]
        public long PaymentDividendsOtherCashDistributions { get; set; }

        [JsonProperty("netCashFlowFromFinancing")]
        public long NetCashFlowFromFinancing { get; set; }

        [JsonProperty("netCashFlowFromInvesting")]
        public long NetCashFlowFromInvesting { get; set; }

        [JsonProperty("netCashFlowInvestmentAcquisitionsDisposals")]
        public long NetCashFlowInvestmentAcquisitionsDisposals { get; set; }

        [JsonProperty("netCashFlowFromOperations")]
        public long NetCashFlowFromOperations { get; set; }

        [JsonProperty("effectOfExchangeRateChangesOnCash")]
        public long EffectOfExchangeRateChangesOnCash { get; set; }

        [JsonProperty("netIncome")]
        public long NetIncome { get; set; }

        [JsonProperty("netIncomeCommonStock")]
        public long NetIncomeCommonStock { get; set; }

        [JsonProperty("netIncomeCommonStockUSD")]
        public long NetIncomeCommonStockUsd { get; set; }

        [JsonProperty("netLossIncomeFromDiscontinuedOperations")]
        public long NetLossIncomeFromDiscontinuedOperations { get; set; }

        [JsonProperty("netIncomeToNonControllingInterests")]
        public long NetIncomeToNonControllingInterests { get; set; }

        [JsonProperty("profitMargin")]
        public long ProfitMargin { get; set; }

        [JsonProperty("operatingExpenses")]
        public long OperatingExpenses { get; set; }

        [JsonProperty("operatingIncome")]
        public long OperatingIncome { get; set; }

        [JsonProperty("tradeAndNonTradePayables")]
        public long TradeAndNonTradePayables { get; set; }

        [JsonProperty("payoutRatio")]
        public long PayoutRatio { get; set; }

        [JsonProperty("priceToBookValue")]
        public long PriceToBookValue { get; set; }

        [JsonProperty("priceEarnings")]
        public long PriceEarnings { get; set; }

        [JsonProperty("priceToEarningsRatio")]
        public long PriceToEarningsRatio { get; set; }

        [JsonProperty("propertyPlantEquipmentNet")]
        public long PropertyPlantEquipmentNet { get; set; }

        [JsonProperty("preferredDividendsIncomeStatementImpact")]
        public long PreferredDividendsIncomeStatementImpact { get; set; }

        [JsonProperty("sharePriceAdjustedClose")]
        public long SharePriceAdjustedClose { get; set; }

        [JsonProperty("priceSales")]
        public long PriceSales { get; set; }

        [JsonProperty("priceToSalesRatio")]
        public long PriceToSalesRatio { get; set; }

        [JsonProperty("tradeAndNonTradeReceivables")]
        public long TradeAndNonTradeReceivables { get; set; }

        [JsonProperty("accumulatedRetainedEarningsDeficit")]
        public long AccumulatedRetainedEarningsDeficit { get; set; }

        [JsonProperty("revenues")]
        public long Revenues { get; set; }

        [JsonProperty("revenuesUSD")]
        public long RevenuesUsd { get; set; }

        [JsonProperty("researchAndDevelopmentExpense")]
        public long ResearchAndDevelopmentExpense { get; set; }

        [JsonProperty("returnOnAverageAssets")]
        public long ReturnOnAverageAssets { get; set; }

        [JsonProperty("returnOnAverageEquity")]
        public long ReturnOnAverageEquity { get; set; }

        [JsonProperty("returnOnInvestedCapital")]
        public long ReturnOnInvestedCapital { get; set; }

        [JsonProperty("returnOnSales")]
        public long ReturnOnSales { get; set; }

        [JsonProperty("shareBasedCompensation")]
        public long ShareBasedCompensation { get; set; }

        [JsonProperty("sellingGeneralAndAdministrativeExpense")]
        public long SellingGeneralAndAdministrativeExpense { get; set; }

        [JsonProperty("shareFactor")]
        public long ShareFactor { get; set; }

        [JsonProperty("shares")]
        public long Shares { get; set; }

        [JsonProperty("weightedAverageShares")]
        public long WeightedAverageShares { get; set; }

        [JsonProperty("weightedAverageSharesDiluted")]
        public long WeightedAverageSharesDiluted { get; set; }

        [JsonProperty("salesPerShare")]
        public long SalesPerShare { get; set; }

        [JsonProperty("tangibleAssetValue")]
        public long TangibleAssetValue { get; set; }

        [JsonProperty("taxAssets")]
        public long TaxAssets { get; set; }

        [JsonProperty("incomeTaxExpense")]
        public long IncomeTaxExpense { get; set; }

        [JsonProperty("taxLiabilities")]
        public long TaxLiabilities { get; set; }

        [JsonProperty("tangibleAssetsBookValuePerShare")]
        public long TangibleAssetsBookValuePerShare { get; set; }

        [JsonProperty("workingCapital")]
        public long WorkingCapital { get; set; }
    }
}
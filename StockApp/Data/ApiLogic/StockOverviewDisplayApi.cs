using Newtonsoft.Json;
using StockApp.Data.ApiResults;
using StockApp.Models;

namespace StockApp.Data.ApiLogic
{
    public class StockOverviewDisplayApi
    {

        public StockDisplayModel GetStockOverviewDisplay(string stock)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.alphavantage.co/query?function=OVERVIEW&symbol=TSLA&apikey=fe96c29976msh7164fa7f072bef1p19efc6jsn0ad83cbe2bb2"),
                Headers =
                    {
                        { "X-RapidAPI-Key", "fe96c29976msh7164fa7f072bef1p19efc6jsn0ad83cbe2bb2" },
                        { "X-RapidAPI-Host", "alpha-vantage.p.rapidapi.com" },
                    },
            };

            using (var response = client.SendAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync().Result;

                var display = JsonConvert.DeserializeObject<StockOverviewResults>(body);

                var stockDisplayModel = new StockDisplayModel();

                stockDisplayModel.Symbol = display.Symbol;
                stockDisplayModel.AssetType = display.AssetType;
                stockDisplayModel.Name = display.Name;
                stockDisplayModel.Description = display.Description;
                stockDisplayModel.Exchange = display.Exchange;
                stockDisplayModel.Country = display.Country;
                stockDisplayModel.Sector = display.Sector;
                stockDisplayModel.Industry = display.Industry;
                stockDisplayModel.Address = display.Address;
                stockDisplayModel.FiscalYearEnd = display.FiscalYearEnd;
                stockDisplayModel.MarketCapitalization = display.MarketCapitalization;
                stockDisplayModel.PERatio = display.PERatio;
                stockDisplayModel.DividendPerShare = display.DividendPerShare;
                stockDisplayModel.DividendYield = display.DividendYield;
                stockDisplayModel.QuarterlyEarningsGrowthYOY = display.QuarterlyEarningsGrowthYOY;
                stockDisplayModel.AnalystTargetPrice = display.AnalystTargetPrice;
                stockDisplayModel.TrailingPE = display.TrailingPE;
                stockDisplayModel._52WeekHigh = display._52WeekHigh;
                stockDisplayModel._52WeekLow = display._52WeekLow;
                stockDisplayModel._50DayMovingAverage = display._50DayMovingAverage;
                stockDisplayModel._200DayMovingAverage = display._200DayMovingAverage;
                stockDisplayModel.SharesOutstanding = display.SharesOutstanding;
                stockDisplayModel.DividendDate = display.DividendDate;


                return stockDisplayModel;


            }

        }


    }
}

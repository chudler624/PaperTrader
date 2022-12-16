using Newtonsoft.Json;
using StockApp.Data.ApiResults.DisplayPageResults;
using StockApp.Models.DisplayPageModels;

namespace StockApp.Data.ApiLogic
{
    public class StockOverviewDisplayApi
    {
        public StockOverviewModel GetStockOverviewDisplay(string stock)
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

                var stockDisplayModel = new StockOverviewModel();

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

        public QuoteModel GetQuote(string stock)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://alpha-vantage.p.rapidapi.com/query?function=GLOBAL_QUOTE&symbol=TSLA&datatype=json"),
                Headers =
                {
                    { "X-RapidAPI-Key", "fe96c29976msh7164fa7f072bef1p19efc6jsn0ad83cbe2bb2" },
                    { "X-RapidAPI-Host", "alpha-vantage.p.rapidapi.com" },
                },
            };

            using (var response = client.SendAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                var body =  response.Content.ReadAsStringAsync().Result;

                var quote = JsonConvert.DeserializeObject<GlobalQuote>(body);

                var quoteModel = new QuoteModel();

                quoteModel.Symbol = quote._01symbol;
                quoteModel.Open = quote._02open;
                quoteModel.High = quote._03high;
                quoteModel.Low = quote._04low;
                quoteModel.Price = quote._05price;
                quoteModel.Volume = quote._06volume;
                quoteModel.LatestTradingDay = quote._07latesttradingday;
                quoteModel.PreviousClose = quote._08previousclose;
                quoteModel.Change = quote._09change;
                quoteModel.ChangePercent = quote._10changepercent;


                return quoteModel;
            }
        }
    }
}




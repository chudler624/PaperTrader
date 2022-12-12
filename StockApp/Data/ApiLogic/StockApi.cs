namespace StockApp.Data.ApiLogic
{
    public class StockApi
    {

        public StockApi() { }

        public void GetIntraday()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://alpha-vantage.p.rapidapi.com/query?interval=5min&function=TIME_SERIES_INTRADAY&symbol=MSFT&datatype=json&output_size=compact"),
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

            }
        }

        public void GetDailyAdjusted()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://alpha-vantage.p.rapidapi.com/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol=MSFT&outputsize=compact&datatype=json"),
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
                Console.WriteLine(body);
            }
        }

        public void GetWeeklyAdjusted()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://alpha-vantage.p.rapidapi.com/query?function=TIME_SERIES_WEEKLY_ADJUSTED&symbol=MSFT&datatype=json"),
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
                
            }
        }

        public void GetMonthlyAdjusted()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://alpha-vantage.p.rapidapi.com/query?symbol=MSFT&function=TIME_SERIES_MONTHLY_ADJUSTED&datatype=json"),
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
                Console.WriteLine(body);
            }
        }

    }
}

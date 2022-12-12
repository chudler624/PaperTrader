using Newtonsoft.Json;
using StockApp.Data.ApiResults;
using StockApp.Models;

namespace StockApp.Data.ApiLogic
{
    public class NewsApi
    {
        public List<NewsModel> GetStockNews(string stock)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.alphavantage.co/query?function=NEWS_SENTIMENT&tickers=IBM&topics=technology&apikey=fe96c29976msh7164fa7f072bef1p19efc6jsn0ad83cbe2bb2"),
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

                var story = JsonConvert.DeserializeObject<NewsResults>(body);

                var newsModel = new List<NewsModel>();

                foreach(var item in story.feed)
                {
                    newsModel.Add(new NewsModel
                    {
                        Title = item.title,
                        Url = item.url,
                        Time_Published = item.time_published,
                        Authors = item.authors,
                        Summary = item.summary,
                        Banner_image = item.banner_image,
                        Source = item.source,
                        Source_domain = item.source_domain,
                        Overall_Sentiment_Score = item.overall_sentiment_score,
                        Overall_Sentiment_Label = item.overall_sentiment_label, 
                        
                    });

                }

                return newsModel;


            };




        }



    }
}


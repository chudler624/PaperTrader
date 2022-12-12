namespace StockApp.Models
{
    public class NewsModel
    {
                
        public string Title { get; set; }
        public string Url { get; set; }
        public string Time_Published { get; set; }
        public List<string> Authors { get; set; }
        public string Summary { get; set; }
        public string Banner_image { get; set; }
        public string Source { get; set; }
        public string Source_domain { get; set; }
        public double Overall_Sentiment_Score { get; set; }
        public string Overall_Sentiment_Label { get; set; }
        public string Ticker { get; set; }
        public string Relevance_Score { get; set; }
        public string Ticker_Sentiment_Score { get; set; }
        public string Ticker_Sentiment_Label { get; set; }







    }
}

using Microsoft.AspNetCore.Mvc;

namespace StockApp.Data.ApiLogic
{
    public class SearchApi
    {
        // C# code
        public class MyController : Controller
        {
            public ActionResult GetSuggestions(string term)
            {
                // Search your database or other data source for suggestions that match the user's input
                var suggestions = new List<KeyValuePair<string, string>>();
                suggestions.Add(new KeyValuePair<string, string>("Key 1", "Value 1"));
                suggestions.Add(new KeyValuePair<string, string>("Key 2", "Value 2"));
                suggestions.Add(new KeyValuePair<string, string>("Key 3", "Value 3"));
                // Return the list of suggestions as a JSON object
                return Json(suggestions);
            }
        }


    }
}

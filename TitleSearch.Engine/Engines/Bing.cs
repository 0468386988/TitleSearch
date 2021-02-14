using System.Collections.Generic;
using System.Threading.Tasks;

namespace TitleSearch.Engine.Engines
{
    public class Bing : BaseEngine
    {
        public Bing()
        {
            EngineName = "Bing";
            TextLink = "<li class=\"b_algo\">";
            TextTarget = $"<h2><a href=\"";
        }

        override public async Task<List<string>> Search()
        {
            List<string> resultURLs = new List<string>();

            // use keyword and engine api to search, then get different pages. Here mock the flow
            for (int i = 1; i < 11; i++)
            {
                string num = i.ToString("D2");
                resultURLs.Add($"https://infotrack-tests.infotrack.com.au/Bing/Page{num}.html");
            }

            return resultURLs;
        }
    }
}
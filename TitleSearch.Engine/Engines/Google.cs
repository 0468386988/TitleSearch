using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TitleSearch.Engine.Engines
{
    public class Google : BaseEngine
    {
        public Google()
        {
            EngineName = "Google";
            TextLink = "<div class=\"r\"><a href=\"https:";
            TextTarget = $"<div class=\"r\"><a href=\"";
        }

        override public async Task<List<string>> Search()
        {
            // use keyword and engine api to search, then get different pages. Here mock the flow
            List<string> resultURLs = new List<string>();

            for (int i = 1; i < 11; i++)
            {
                string num = i.ToString("D2");
                resultURLs.Add($"https://infotrack-tests.infotrack.com.au/Google/Page{num}.html");
            }

            return resultURLs;
        }
    }
}
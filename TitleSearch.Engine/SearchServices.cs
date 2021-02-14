using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitleSearch.Engine.Engines;
using TitleSearch.Engine.Interfaces;

namespace TitleSearch.Engine
{
    public class SearchServices : ISearchServices
    {
        public async Task<List<Tuple<string, string>>> GetPositionNumber(List<string> in_lstEngineSelected,
            string in_strKeyWords,
            string in_strDomainUR,
            int in_iWithin
            )
        {
            List<Tuple<string, string>> res = new List<Tuple<string, string>>();
            EngineFactory factory = new EngineFactory();

            foreach (var item in in_lstEngineSelected)
            {
                BaseEngine engine = factory.GetEngine(item.ToLower());
                engine.SetDomainURL(in_strDomainUR);
                engine.SetKeyWords(in_strKeyWords);
                engine.SetWithinNumber(in_iWithin);

                res.Add(new Tuple<string, string>(item, await engine.GetPositionNumber()));
            }

            return res;
        }

        public List<string> GetSupportedSearchEngine()
        {
            List<string> supportedEngines = new List<string> { "Google", "Bing" };

            return supportedEngines;
        }
    }
}
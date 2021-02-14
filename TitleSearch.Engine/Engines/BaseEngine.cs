using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TitleSearch.Engine.Interfaces;

namespace TitleSearch.Engine.Engines
{
    public class BaseEngine
    {
        public string EngineName { get; set; }
        public string BaseURL { get; set; }
        public string KeyWord { get; set; }
        public string DomainURL { get; set; }
        public int RankLimitaion { get; set; }
        public string TextLink { get; set; }
        public string TextTarget { get; set; }
        public HttpClient _httpClient;

        public BaseEngine()
        {
            _httpClient = new HttpClient();
            RankLimitaion = 50;
        }

        public async Task<string> GetPositionNumber()
        {
            List<string> urls = await Search();

            return await Parse(urls);
        }

        virtual public async Task<string> Parse(List<string> in_lstURLs)
        {
            string result = "";
            int iPosition = 0;
            foreach (var url in in_lstURLs)
            {
                var html = await _httpClient.GetStringAsync(url);

                MatchCollection matchLinks = Regex.Matches(html, TextLink);

                string textTarget = TextTarget + DomainURL;
                MatchCollection matchTargets = Regex.Matches(html, textTarget);

                int i = 0;
                for (int j = 0; j < matchLinks.Count; j++)
                {
                    for (; i < matchTargets.Count;)
                    {
                        if (matchTargets[i].Groups[0].Index >= matchLinks[j].Groups[0].Index &&
                            matchTargets[i].Groups[0].Index < ((j < matchLinks.Count - 1) ? matchLinks[j + 1].Groups[0].Index : html.Length))
                        {
                            result += result.Length > 0 ? "," : null;
                            result += $"{j + 1 + iPosition}";
                            i++;
                        }
                        else
                            break;
                    }
                }
                iPosition += matchLinks.Count;

                if (iPosition >= RankLimitaion) break;
            }

            result += result.Length == 0 ? "0" : "";
            return result;
        }

        virtual public async Task<List<string>> Search()
        {
            return null;
        }

        public string GetEngineName()
        {
            return EngineName;
        }

        public void SetDomainURL(string in_strDomainURL)
        {
            DomainURL = in_strDomainURL;
        }

        public void SetKeyWords(string in_strKeyWords)
        {
            KeyWord = in_strKeyWords;
        }

        public void SetWithinNumber(int in_iKeyWords)
        {
            RankLimitaion = in_iKeyWords;
        }
    }
}
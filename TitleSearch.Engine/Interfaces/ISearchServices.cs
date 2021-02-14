using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TitleSearch.Engine.Interfaces
{
    public interface ISearchServices
    {
        List<string> GetSupportedSearchEngine();

        Task<List<Tuple<string, string>>> GetPositionNumber(List<string> in_lstEngineSelected,
            string in_strKeyWords,
            string in_strDomainUR,
            int in_iWithin);
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TitleSearch.Engine.Interfaces
{
    public interface IEngine
    {
        string GetEngineName();

        void SetKeyWords(string in_strKeyWords);

        void SetDomainURL(string in_strDomainURL);

        Task<int> GetPositionNumber();
    }
}
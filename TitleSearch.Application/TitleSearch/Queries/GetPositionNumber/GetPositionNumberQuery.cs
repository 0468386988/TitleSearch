using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TitleSearch.Application.TitleSearch.Queries.GetPositionNumber
{
    public class GetPositionNumberQuery : IRequest<List<Tuple<string, string>>>
    {
        public string KeyWords { get; set; }
        public string URL { get; set; }
        public string Engines { get; set; }
        public int Within { get; set; }
    }
}
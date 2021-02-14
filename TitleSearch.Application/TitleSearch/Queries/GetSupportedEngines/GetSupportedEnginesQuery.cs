using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TitleSearch.Application.TitleSearch.Queries.GetSupportedEngines
{
    public class GetSupportedEnginesQuery : IRequest<List<string>>
    {
    }
}
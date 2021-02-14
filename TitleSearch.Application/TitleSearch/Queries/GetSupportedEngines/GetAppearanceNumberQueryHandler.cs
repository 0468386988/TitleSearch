using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TitleSearch.Engine.Interfaces;

namespace TitleSearch.Application.TitleSearch.Queries.GetSupportedEngines
{
    public class GetSupportedEnginesQueryHandler : IRequestHandler<GetSupportedEnginesQuery, List<string>>
    {
        private readonly ISearchServices _searchServices;

        public GetSupportedEnginesQueryHandler(ISearchServices searchServices)
        {
            _searchServices = searchServices;
        }

        public async Task<List<string>> Handle(GetSupportedEnginesQuery request, CancellationToken cancellationToken)
        {
            return _searchServices.GetSupportedSearchEngine();
        }
    }
}
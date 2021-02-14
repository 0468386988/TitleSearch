using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TitleSearch.Engine.Interfaces;

namespace TitleSearch.Application.TitleSearch.Queries.GetPositionNumber
{
    public class GetPositionNumberQueryHandler : IRequestHandler<GetPositionNumberQuery, List<Tuple<string, string>>>
    {
        private readonly ISearchServices _searchServices;

        public GetPositionNumberQueryHandler(ISearchServices searchServices)
        {
            _searchServices = searchServices;
        }

        public async Task<List<Tuple<string, string>>> Handle(GetPositionNumberQuery request, CancellationToken cancellationToken)
        {
            List<string> selectedEngines = new List<string>(request.Engines.Split(' '));

            List<string> supportedEngines = _searchServices.GetSupportedSearchEngine();
            foreach (var engine in selectedEngines)
            {
                var match = supportedEngines.FirstOrDefault(e => e.ToLower() == engine.ToLower());

                if (match == null)
                {
                    ValidationException exception = new ValidationException($"{engine} is not supported!");
                    throw exception;
                }
            }

            List<Tuple<string, string>> lstNumbers = await _searchServices.GetPositionNumber(
                selectedEngines,
                request.KeyWords,
                request.URL,
                request.Within);

            return lstNumbers;
        }
    }
}
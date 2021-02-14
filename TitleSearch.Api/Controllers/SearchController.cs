using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TitleSearch.Application.Common.Exceptions;
using TitleSearch.Application.TitleSearch.Queries.GetPositionNumber;

namespace TitleSearch.Api.Controllers
{
    public class SearchController : BaseController
    {
        private readonly ILogger<SearchController> _logger;

        public SearchController(ILogger<SearchController> logger)
        {
            _logger = logger;
        }

        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/search
        ///     {
        ///        "keywords": "online title search",
        ///        "url": "https://www.infotrack.com.au",
        ///        "engines": "google bing"
        ///        "within": 50
        ///     }
        ///
        /// </remarks>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Tuple<string, string>>>> Get(string keywords, string url, string engines, int within)
        {
            GetPositionNumberQuery query = new GetPositionNumberQuery
            {
                KeyWords = keywords,
                URL = url,
                Engines = engines,
                Within = within
            };
            List<Tuple<string, string>> numbers = new List<Tuple<string, string>>();
            try
            {
                numbers = await Mediator.Send(query);
            }
            catch (ValidationException e)
            {
                var context = HttpContext.Features.Get<ValidationException>();
                string details = string.Join(";", e.Failures?.Select(pair => string.Join("", pair.Value)));

                return Problem(
                    detail: details,
                    title: e.Message,
                    statusCode: (int)HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                return Problem(
                    detail: e.Message,
                    title: e.Message,
                    statusCode: (int)HttpStatusCode.BadRequest);
            }

            return Ok(numbers);
        }
    }
}
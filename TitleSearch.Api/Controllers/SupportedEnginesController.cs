using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitleSearch.Application.TitleSearch.Queries.GetSupportedEngines;

namespace TitleSearch.Api.Controllers
{
    public class SupportedEnginesController : BaseController
    {
        private readonly ILogger<SupportedEnginesController> _logger;

        public SupportedEnginesController(ILogger<SupportedEnginesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<string>> Get()
        {
            GetSupportedEnginesQuery query = new GetSupportedEnginesQuery();
            List<string> names = await Mediator.Send(query);
            return names;
        }
    }
}
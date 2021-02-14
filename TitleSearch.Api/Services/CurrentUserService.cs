using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitleSearch.Application.Common.Interfaces;

namespace TitleSearch.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string UserId { get; }

        public bool IsAuthenticated { get; }
    }
}
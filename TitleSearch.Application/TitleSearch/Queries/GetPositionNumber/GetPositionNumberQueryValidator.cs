using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TitleSearch.Application.TitleSearch.Queries.GetPositionNumber
{
    public class GetPositionNumberQueryValidator : AbstractValidator<GetPositionNumberQuery>
    {
        public GetPositionNumberQueryValidator()
        {
            RuleFor(v => v.KeyWords).NotEmpty();
            RuleFor(v => v.URL).NotEmpty();
            RuleFor(v => v.Engines).NotEmpty();
            RuleFor(v => v.Within).LessThanOrEqualTo(200).GreaterThan(0);
        }
    }
}
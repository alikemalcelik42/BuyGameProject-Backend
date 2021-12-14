using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{

    public class CampaignValidator : AbstractValidator<Campaign>
    {
        public CampaignValidator()
        {
            RuleFor(c => c.Name).MinimumLength(3).MaximumLength(50);
            RuleFor(c => c.DiscountPercentage).GreaterThan(0).LessThan(100);
            RuleFor(c => c.FinishDate).GreaterThan(DateTime.Now);
        }
    }
}

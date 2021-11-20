using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.Autofac
{

    public class CampaignValidator : AbstractValidator<Campaign>
    {
        public CampaignValidator()
        {
            RuleFor(c => c.Name).MinimumLength(3).MaximumLength(5).NotEmpty();
            RuleFor(c => c.DiscountPercentage).GreaterThan(0).NotEmpty();
            RuleFor(c => c.FinishDate).GreaterThan(DateTime.Now).NotEmpty();
        }
    }
}

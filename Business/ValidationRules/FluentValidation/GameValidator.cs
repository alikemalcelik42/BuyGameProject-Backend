using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(g => g.Name).MinimumLength(5).MaximumLength(200);
            RuleFor(g => g.UnitPrice).GreaterThan(0);
        }
    }
}

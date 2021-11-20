using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.Autofac
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(g => g.Name).MinimumLength(5).MinimumLength(200).NotEmpty();
            RuleFor(g => g.UnitPrice).GreaterThan(0).NotEmpty();
        }
    }
}

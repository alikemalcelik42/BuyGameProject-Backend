using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.Autofac
{
    public class GamerValidator : AbstractValidator<Gamer>
    {
        public GamerValidator()
        {
            RuleFor(g => g.NationalNumber).Length(11).NotEmpty();
        }
    }
}

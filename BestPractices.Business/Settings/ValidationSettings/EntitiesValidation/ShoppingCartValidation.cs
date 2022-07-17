using BestPractices.Business.Extensions;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Enums;
using FluentValidation;

namespace BestPractices.Business.Settings.ValidationSettings.EntitiesValidation
{
    public class ShoppingCartValidation : Validate<ShoppingCart>
    {
        public ShoppingCartValidation()
        {
            SetRules();
        }

        private void SetRules()
        {
            RuleForEach(s => s.Products).SetValidator(new ProductValidation());

            RuleFor(s => s.TotalItens).GreaterThan(0).WithMessage(EMessage.FillError.Description().FormatTo("Needs at least one item"));

            RuleFor(s => s.TotalAmount).GreaterThan(0).WithMessage(EMessage.FillError.Description().FormatTo("Needs at least one item"));
        }
    }
}

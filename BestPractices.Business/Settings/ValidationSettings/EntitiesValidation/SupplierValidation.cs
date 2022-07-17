using BestPractices.Business.Extensions;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Enums;
using FluentValidation;

namespace BestPractices.Business.Settings.ValidationSettings.EntitiesValidation
{
    public class SupplierValidation : Validate<Supplier>
    {
        public SupplierValidation()
        {
            SetRules();
        }

        private void SetRules()
        {
            RuleFor(s => s.CompanyAddress).SetValidator(new AddressValidation());

            RuleFor(s => s.CNPJ).Length(14).Must(c => !c.All(c => char.IsWhiteSpace(c)))
                .WithMessage(s => string.IsNullOrWhiteSpace(s.CNPJ)
               ? EMessage.Required.Description().FormatTo("CNPJ")
               : EMessage.MoreExpected.Description().FormatTo("CNPJ", "14"));

            RuleFor(s => s.CompanyName).Length(3, 255).Must(c => !c.All(c => char.IsWhiteSpace(c)))
               .WithMessage(s => string.IsNullOrWhiteSpace(s.CompanyName)
              ? EMessage.Required.Description().FormatTo("Company Name")
              : EMessage.MoreExpected.Description().FormatTo("Company Name", "between {MinLength} to {Maxlength}"));
        }
    }
}

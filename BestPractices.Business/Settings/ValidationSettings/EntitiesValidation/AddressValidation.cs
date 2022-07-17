using BestPractices.Business.Extensions;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Enums;
using FluentValidation;

namespace BestPractices.Business.Settings.ValidationSettings.EntitiesValidation
{
    public class AddressValidation : Validate<Address>
    {
        public AddressValidation()
        {
            SetRules();
        }

        private void SetRules()
        {

            RuleFor(a => a.ZipCode).Length(8).Must(c => !c.All(c => char.IsWhiteSpace(c)))
                .WithMessage(a => string.IsNullOrWhiteSpace(a.ZipCode)
               ? EMessage.Required.Description().FormatTo("Zip Code")
               : EMessage.MoreExpected.Description().FormatTo("Zip Code", "8"));

            RuleFor(a => a.City).Length(3, 80).Must(c => !c.All(c => char.IsWhiteSpace(c)))
                .WithMessage(a => string.IsNullOrWhiteSpace(a.City)
               ? EMessage.Required.Description().FormatTo("City")
               : EMessage.MoreExpected.Description().FormatTo("City", "between {MinLength} to {Maxlength}"));

            RuleFor(a => a.Street).Length(3, 100).Must(Street => !Street.All(c => char.IsWhiteSpace(c)))
                .WithMessage(a => string.IsNullOrWhiteSpace(a.Street)
                ? EMessage.Required.Description().FormatTo("Street")
                : EMessage.MoreExpected.Description().FormatTo("Street", "between {MinLength} to {Maxlength}"));

            RuleFor(a => a.State).Length(2).Must(c => !c.All(c => char.IsWhiteSpace(c)))
                .WithMessage(a => string.IsNullOrWhiteSpace(a.State)
               ? EMessage.Required.Description().FormatTo("State")
               : EMessage.MoreExpected.Description().FormatTo("State", "2"));

            RuleFor(a => a.Number).Length(2, 10).Must(c => !c.All(c => char.IsWhiteSpace(c)))
                .WithMessage(a => string.IsNullOrWhiteSpace(a.Number)
               ? EMessage.Required.Description().FormatTo("Number")
               : EMessage.MoreExpected.Description().FormatTo("Number", "between {MinLength} to {Maxlength}"));

            When(a => !string.IsNullOrEmpty(a.Complement), () =>
            {
                RuleFor(a => a.Complement).Length(3, 100).Must(c => !c.All(c => char.IsWhiteSpace(c)))
                .WithMessage(a => string.IsNullOrWhiteSpace(a.Complement)
                    ? EMessage.Required.Description().FormatTo("Complement")
                    : EMessage.MoreExpected.Description().FormatTo("Complement", "{MinLength} a {Maxlength}"));

            });
        }
    }
}

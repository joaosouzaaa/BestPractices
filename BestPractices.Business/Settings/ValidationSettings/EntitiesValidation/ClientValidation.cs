using BestPractices.Business.Extensions;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Enums;
using FluentValidation;

namespace BestPractices.Business.Settings.ValidationSettings.EntitiesValidation
{
    public class ClientValidation : Validate<Client>
    {
        public ClientValidation()
        {
            SetRules();
        }

        private void SetRules()
        {
            RuleFor(c => c.Name).Length(3, 255).Must(c => !c.All(c => char.IsWhiteSpace(c)))
               .WithMessage(c => string.IsNullOrWhiteSpace(c.Name)
              ? EMessage.Required.Description().FormatTo("Client Name")
              : EMessage.MoreExpected.Description().FormatTo("ClientName", "3 to 255"));

            RuleFor(c => c.LastName).Length(3, 255).Must(c => !c.All(c => char.IsWhiteSpace(c)))
               .WithMessage(c => string.IsNullOrWhiteSpace(c.LastName)
              ? EMessage.Required.Description().FormatTo("Client Last Name")
              : EMessage.MoreExpected.Description().FormatTo("Client Last Name", "3 to 255"));

            RuleFor(c => c.BirthDate).InclusiveBetween(DateTime.Now.AddYears(-100), DateTime.Today)
                    .WithMessage(c => string.IsNullOrEmpty(c.BirthDate.ToString())
                    ? EMessage.InvalidAge.Description().FormatTo("{PropertyValue}")
                    : EMessage.Required.Description().FormatTo("BirthDate"));

            RuleFor(p => p.DocumentNumber).NotEmpty().WithMessage(EMessage.Required.Description()
                .FormatTo("Client CPF"));
        }
    }
}

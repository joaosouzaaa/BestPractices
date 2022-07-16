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
            RuleFor(p => p.Name).NotEmpty().WithMessage(EMessage.Required.Description()
                .FormatTo("Client Name"));

            RuleFor(p => p.Name).Length(3, 255).WithMessage(EMessage.MoreExpected.Description()
                .FormatTo("Client Name", "3 a 255"));

            RuleFor(p => p.LastName).NotEmpty().WithMessage(EMessage.Required.Description()
                .FormatTo("Client Last Name"));

            RuleFor(p => p.Name).Length(3, 255).WithMessage(EMessage.MoreExpected.Description()
                .FormatTo("Client Last Name", "3 a 255"));

            RuleFor(p => p.BirthDate).NotEmpty().WithMessage(EMessage.Required.Description()
                .FormatTo("Birth Date"));

            RuleFor(p => p.DocumentNumber).NotEmpty().WithMessage(EMessage.Required.Description()
                .FormatTo("Client CPF"));
        }
    }
}

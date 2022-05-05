using BestPractices.Domain.Entities;
using BestPractices.Domain.Enums;
using BestPractices.Domain.Extensions;
using FluentValidation;

namespace BestPractices.Domain.EntitiesValidation
{
    public class ClientValidation : AbstractValidator<Client>
    {
        public ClientValidation()
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

            RuleFor(p => p.Age).NotEmpty().WithMessage(EMessage.Required.Description()
                .FormatTo("Client Age"));

            RuleFor(p => p.Age).GreaterThan(17).WithMessage(EMessage.InvalidAge.Description()
                .FormatTo("Client Age"));

            RuleFor(p => p.CPF).NotEmpty().WithMessage(EMessage.Required.Description()
                .FormatTo("Client CPF"));
        }
    }
}

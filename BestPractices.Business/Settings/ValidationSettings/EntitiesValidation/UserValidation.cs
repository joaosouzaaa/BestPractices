using BestPractices.Business.Extensions;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Enums;
using FluentValidation;

namespace BestPractices.Business.Settings.ValidationSettings.EntitiesValidation
{
    public class UserValidation : Validate<User>
    {
        public UserValidation()
        {
            SetRules();
        }

        private void SetRules()
        {
            RuleFor(u => u.Client).SetValidator(new ClientValidation());

            RuleFor(u => u.Email).EmailAddress().WithMessage(EMessage.InvalidFormat.Description());

            RuleFor(u => u.PasswordHash).Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$")
                .WithMessage("Must have at least 8 characters, at least one number and one special character");
        }
    }
}

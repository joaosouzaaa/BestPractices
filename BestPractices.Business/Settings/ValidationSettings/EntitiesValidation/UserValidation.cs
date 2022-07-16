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
            RuleFor(u => u.Email).EmailAddress().WithMessage(EMessage.InvalidFormat.Description());
        }
    }
}

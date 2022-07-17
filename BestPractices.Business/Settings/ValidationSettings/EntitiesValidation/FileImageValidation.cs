using BestPractices.Business.Extensions;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Enums;
using FluentValidation;

namespace BestPractices.Business.Settings.ValidationSettings.EntitiesValidation
{
    public class FileImageValidation : Validate<FileImage>
    {
        public FileImageValidation()
        {
            SetRules();
        }

        private void SetRules()
        {
            RuleFor(f => f.ImageBytes).NotEmpty().WithMessage(EMessage.Required.Description().FormatTo("FileImage"));

            RuleFor(f => f.FileName).Length(3, 255).Must(f => !f.All(c => char.IsWhiteSpace(c)))
                .WithMessage(f => string.IsNullOrWhiteSpace(f.FileName)
                ? EMessage.Required.Description().FormatTo("File Name")
                : EMessage.MoreExpected.Description().FormatTo("File Name", "between {MinLength} to {Maxlength}"));

            RuleFor(f => f.FileExtension).Length(3, 50).Must(f => !f.All(c => char.IsWhiteSpace(c)))
                .WithMessage(f => string.IsNullOrWhiteSpace(f.FileExtension)
                ? EMessage.Required.Description().FormatTo("File Extension")
                : EMessage.MoreExpected.Description().FormatTo("File Extension", "between {MinLength} to {Maxlength}"));
        }
    }
}

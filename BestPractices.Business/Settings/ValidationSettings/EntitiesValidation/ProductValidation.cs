using BestPractices.Business.Extensions;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Enums;
using FluentValidation;

namespace BestPractices.Business.Settings.ValidationSettings.EntitiesValidation
{
    public class ProductValidation : Validate<Product>
    {
        public ProductValidation()
        {
            SetRules();
        }

        private void SetRules()
        {
            When(p => p.FileImage != null, () =>
            {
                RuleFor(p => p.FileImage).SetValidator(new FileImageValidation());
            });

            RuleFor(p => p.ProductName).Length(3, 255).Must(p => !p.All(c => char.IsWhiteSpace(c)))
               .WithMessage(p => string.IsNullOrWhiteSpace(p.ProductName)
               ? EMessage.Required.Description().FormatTo("Product Name")
               : EMessage.MoreExpected.Description().FormatTo("Product Name", "between {MinLength} to {Maxlength}"));

            RuleFor(p => p.Price).GreaterThan(0)
               .WithMessage(p => p.Price == null
               ? EMessage.Required.Description().FormatTo("Price")
               : EMessage.FillError.Description().FormatTo("Price needs to be greater than 0"));

            RuleFor(p => p.Brand).Length(3, 100).Must(p => !p.All(c => char.IsWhiteSpace(c)))
               .WithMessage(p => string.IsNullOrWhiteSpace(p.Brand)
               ? EMessage.Required.Description().FormatTo("Brand")
               : EMessage.MoreExpected.Description().FormatTo("Brand", "between {MinLength} to {Maxlength}"));

            RuleFor(p => p.Category).NotEmpty().WithMessage(EMessage.Required.Description().FormatTo("Category"));

            RuleFor(p => p.Description).NotEmpty().WithMessage(EMessage.Required.Description().FormatTo("Description"));

            RuleFor(p => p.TransportationPrice).GreaterThan(0)
              .WithMessage(p => p.TransportationPrice == null
              ? EMessage.Required.Description().FormatTo("Transportation Price")
              : EMessage.FillError.Description().FormatTo("Transportation Price needs to be greater than 0"));
        }
    }
}

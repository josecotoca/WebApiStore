using FluentValidation;
using WebApiStore.Dtos;

namespace WebApiStore.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator() {
            RuleFor(product => product.Name).NotEmpty().Length(1, 100);
            RuleFor(product => product.Description).NotEmpty().Length(1, 150);
            RuleFor(product => product.Price).NotEmpty().GreaterThan(1);
        }
    }
}

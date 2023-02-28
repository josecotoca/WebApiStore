using FluentValidation;
using WebApiStore.Dtos.Product;

namespace WebApiStore.Validators
{
    public class ProductValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty().Length(1, 100);
            RuleFor(product => product.Description).NotEmpty().Length(1, 150);
            RuleFor(product => product.Price).NotEmpty().GreaterThan(1);
        }
    }
}

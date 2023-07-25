using FluentValidation;
using OrganizationCrudWithMediatr.Commands;

namespace OrganizationCrudWithMediatr.Validation;

public class CreateOrderValidation : AbstractValidator<CreateProductCommand>
{
    public CreateOrderValidation()
    {
        RuleFor(c => c.Description).Length(150).WithMessage("Description length can be maximum 150");
        RuleFor(c => c.Name).NotNull().WithMessage("Product cannot be empty").NotEmpty();
    }
    
}
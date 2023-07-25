using FluentValidation;
using MediatR;
using OrganizationCrudWithMediatr.Commands;
using OrganizationCrudWithMediatr.Models;

namespace OrganizationCrudWithMediatr.Behaviour;
 
public class CreateOrderBehaviour : IPipelineBehavior<CreateProductCommand,ProductModel>
{
    private readonly IValidator<CreateProductCommand> _validator;

    public CreateOrderBehaviour(IValidator<CreateProductCommand> validator)
    {
        _validator = validator;
    }

    public async Task<ProductModel> Handle(
        CreateProductCommand request,
        RequestHandlerDelegate<ProductModel> next,
        CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new ValidationException("CreateScience validation is not valid", validationResult.Errors);
        }

        return await next();
    }
}
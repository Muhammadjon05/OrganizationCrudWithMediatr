using MediatR;
using OrganizationCrudWithMediatr.DbContext;
using OrganizationCrudWithMediatr.Entities;
using OrganizationCrudWithMediatr.Mappers;
using OrganizationCrudWithMediatr.Models;

namespace OrganizationCrudWithMediatr.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,ProductModel>
{
    private readonly OrderDbContext _orderDbContext;
    public CreateProductCommandHandler( OrderDbContext orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }

    public async Task<ProductModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };
        await _orderDbContext.Products.AddAsync(product);
        await _orderDbContext.SaveChangesAsync();
        return product.ToModel();
    }
}
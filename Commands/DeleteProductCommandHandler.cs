using MediatR;
using Microsoft.EntityFrameworkCore;
using OrganizationCrudWithMediatr.DbContext;
using OrganizationCrudWithMediatr.Exception;

namespace OrganizationCrudWithMediatr.Commands;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly OrderDbContext _orderDbContext;

    public DeleteProductCommandHandler(OrderDbContext orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _orderDbContext.Products.FirstOrDefaultAsync(i => i.Id == request.ProductId);
        if (product == null)
        {
            throw new ProductNotFoundException("Product not found");
        }

        _orderDbContext.Products.Remove(product);
        await _orderDbContext.SaveChangesAsync();
    }
}
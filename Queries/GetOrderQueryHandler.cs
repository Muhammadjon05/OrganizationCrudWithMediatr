using MediatR;
using Microsoft.EntityFrameworkCore;
using OrganizationCrudWithMediatr.DbContext;
using OrganizationCrudWithMediatr.Mappers;
using OrganizationCrudWithMediatr.Models;

namespace OrganizationCrudWithMediatr.Queries;

public class GetOrderQueryHandler : IRequestHandler<GetOrdersQuery,IEnumerable<ProductModel>>
{
    private readonly OrderDbContext _orderDbContext;

    public GetOrderQueryHandler(OrderDbContext orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }

    public async Task<IEnumerable<ProductModel>> Handle(
        GetOrdersQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _orderDbContext.Products.AsQueryable();
        var orders = await query.Select(i => i.ToModel()).ToListAsync(cancellationToken);
        return orders;
        
    }
}
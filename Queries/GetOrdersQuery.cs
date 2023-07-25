using MediatR;
using OrganizationCrudWithMediatr.Models;

namespace OrganizationCrudWithMediatr.Queries;

public class GetOrdersQuery : IRequest<IEnumerable<ProductModel>>
{
    
}
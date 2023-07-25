using MediatR;
using OrganizationCrudWithMediatr.Models;

namespace OrganizationCrudWithMediatr.Commands;

public class CreateProductCommand : IRequest<ProductModel>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    
}
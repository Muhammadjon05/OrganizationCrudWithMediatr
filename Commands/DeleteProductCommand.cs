using MediatR;

namespace OrganizationCrudWithMediatr.Commands;

public class DeleteProductCommand : IRequest
{
    public Guid ProductId { get; set; }
    
}
using OrganizationCrudWithMediatr.Entities;
using OrganizationCrudWithMediatr.Models;

namespace OrganizationCrudWithMediatr.Mappers;

public static class Mappers
{
    public static ProductModel ToModel(this Product product)
    {
        var productModel = new ProductModel()
        {
            Id = product.Id,
            Description = product.Description,
            Name = product.Name,
            Price = product.Price
        };
        return productModel;
    }

}
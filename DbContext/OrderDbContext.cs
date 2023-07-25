using Microsoft.EntityFrameworkCore;
using OrganizationCrudWithMediatr.Entities;

namespace OrganizationCrudWithMediatr.DbContext;

public class OrderDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options): base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
}
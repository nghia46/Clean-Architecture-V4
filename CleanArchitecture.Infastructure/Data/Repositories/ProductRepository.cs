using System.Linq.Expressions;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infastructure.Data.Repositories;

public class ProductRepository(AppDbContext appDbContext) : IProductRepository
{
    public async Task<Product> GetByIdAsync(Guid id)
    {
        var product = await appDbContext.Products.FindAsync(id);
        return product ?? throw new KeyNotFoundException($"Product with id {id} not found.");
    }

    public async Task<Product> GetByPropertyAsync(Expression<Func<Product, bool>> predicate)
    {
        var product = await appDbContext.Products.FirstOrDefaultAsync(predicate);
        return product;
    }

    public async Task<IEnumerable<Product>> GetsAsync()
    {
        var products = await appDbContext.Products.ToListAsync();
        return products;
    }
}

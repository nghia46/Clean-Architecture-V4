using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Commands_Queries.Queries.GetsProduct;

public class GetsProductQueryHandler(IProductRepository productRepository) : IRequestHandler<GetsProductQuery, IEnumerable<Product>>
{
    public async Task<IEnumerable<Product>> Handle(GetsProductQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetsAsync();
        return products;
    }
}

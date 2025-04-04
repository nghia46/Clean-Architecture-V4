using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Commands_Queries.Queries.GetsProduct;

public class GetsProductQueryHandler(IProductRepository productRepository) : IRequestHandler<GetsProductQuery, BaseResponse<IEnumerable<Product>>>
{
    public async Task<BaseResponse<IEnumerable<Product>>> Handle(GetsProductQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var products = await productRepository.GetsAsync();
            return BaseResponse<IEnumerable<Product>>.SuccessReturn(products);
        }
        catch
        {
            return BaseResponse<IEnumerable<Product>>.InternalServerError();
        }

    }
}

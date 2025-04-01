using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Commands_Queries.Queries.GetsProduct;

public record GetsProductQuery : IRequest<IEnumerable<Product>>;

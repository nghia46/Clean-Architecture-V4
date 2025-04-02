using CleanArchitecture.Application.Commands_Queries.Commands.ProductDto.CreateProduct;
using MediatR;

namespace CleanArchitecture.Application.Commands_Queries.Commands.CreateProduct;

public record CreateProductCommand(CreateProductDto ProductDto) : IRequest<string>;
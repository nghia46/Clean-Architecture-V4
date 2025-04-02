using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Utils;
using CleanArchitecture.Domain.Entities;
using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Application.Commands_Queries.Commands.CreateProduct;

public class CreateProductCommandHandler(IConfiguration configuration, IProductRepository productRepository, IKafkaHelper<Product> kafkaHelper) : IRequestHandler<CreateProductCommand, string>
{
    public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = new Product(
                request.ProductDto.Name,
                request.ProductDto.Price,
                request.ProductDto.Stock,
                request.ProductDto.Description
            );
            await productRepository.Create(product);
            // get the topic name from the appsettings.json file

            string topicName = configuration["Kafka:Topic:Product"] ?? "undefined-topic";
            await kafkaHelper.ProduceMessageAsync(topicName, product.Id.ToString(), product);

            return product.Id.ToString();
        }
        catch (Exception e)
        {
            return e.Message;
            throw;
        }
    }
}

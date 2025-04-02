using CleanArchitecture.Application.Interfaces.GenericRepository;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;

public interface IProductRepository : IReadRepository<Product>, ICreateRepository<Product>
{

}

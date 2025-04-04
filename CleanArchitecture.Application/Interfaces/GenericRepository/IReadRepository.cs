﻿using System.Linq.Expressions;

namespace CleanArchitecture.Application.Interfaces.GenericRepository;

public interface IReadRepository<T>
{
    Task<IEnumerable<T>> GetsAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<T> GetByPropertyAsync(Expression<Func<T, bool>> predicate);
}
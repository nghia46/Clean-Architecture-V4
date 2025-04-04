﻿namespace CleanArchitecture.Application.Interfaces.GenericRepository;

public interface IFindRepository<T>
{
    Task<IEnumerable<T>> Find(Func<T, bool> predicate);
}
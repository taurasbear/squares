using Microsoft.EntityFrameworkCore;
using Squares.Application.Common.Exceptions;
using Squares.Application.Interfaces.Data;
using Squares.Domain.Entities;

namespace Squares.Infrastructure.Data;

public class Repository(SquaresContext dbContext) : IRepository
{
    public async Task CreateAsync<T>(T entity, CancellationToken cancellationToken) where T : BaseEntity
    {
        await dbContext.Set<T>().AddAsync(entity, cancellationToken);
    }

    public async Task<List<T>> GetAllAsync<T>(CancellationToken cancellationToken) where T : BaseEntity
    {
        return await dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync<T>(Guid id, CancellationToken cancellationToken) where T : BaseEntity
    {
        return await dbContext.Set<T>().FindAsync(id, cancellationToken)
            ?? throw new DbEntityNotFoundException(typeof(T).Name, id);
    }

    public void DeleteAsync<T>(T entity, CancellationToken cancellationToken) where T : BaseEntity
    {
        dbContext.Set<T>().Remove(entity);
    }

    public void UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : BaseEntity
    {
        dbContext.Set<T>().Update(entity);
    }

    public IQueryable<T> AsQueryable<T>() where T : BaseEntity
    {
        return dbContext.Set<T>();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
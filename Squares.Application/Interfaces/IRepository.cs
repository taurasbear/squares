using Squares.Domain.Entities;

namespace Squares.Application.Interfaces;

public interface IRepository
{
    public Task<T> GetByIdAsync<T>(Guid id, CancellationToken cancellationToken) where T : BaseEntity;

    public Task<List<T>> GetAllAsync<T>(CancellationToken cancellationToken) where T : BaseEntity;

    public Task CreateAsync<T>(T entity, CancellationToken cancellationToken) where T : BaseEntity;

    public void DeleteAsync<T>(T entity, CancellationToken cancellationToken) where T : BaseEntity;

    public void UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : BaseEntity;

    public IQueryable<T> AsQueryable<T>() where T : BaseEntity;

    public Task SaveChangesAsync(CancellationToken cancellationToken);
}
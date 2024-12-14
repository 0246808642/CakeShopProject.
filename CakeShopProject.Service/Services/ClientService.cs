using CakeShopProject.Domain.Entities;
using CakeShopProject.Domain.Interface.Repository;
using CakeShopProject.Domain.Interface.Service;
using System.Linq.Expressions;

namespace CakeShopProject.Service.Services;

public class ClientService : IClientService
{

    private readonly IClientRepository _repository;

    public ClientService(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task<Client> AddAsync(Client entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        return await _repository.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<Client> entities)
    {
        if (entities == null || entities.Count == 0) throw new ArgumentException("Entities cannot be null or empty.");
        await _repository.AddRangeAsync(entities);
    }

    public async Task DeleteAsync(Client entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        await _repository.DeleteAsync(entity);
    }

    public async Task<Client> DeletedAsync(long id)
    {
        var client = await _repository.GetByIdAsync(id);
        if (client == null) throw new KeyNotFoundException($"Client with ID {id} not found.");
        return await _repository.DeletedAsync(id);
    }

    public async Task<IEnumerable<Client>> GetAllAsync(Expression<Func<Client, bool>> predicate)
    {
        return await _repository.GetAllAsync(predicate);
    }

    public async Task<Client> GetAsync(Expression<Func<Client, bool>> predicate)
    {
        return await _repository.GetAsync(predicate);
    }

    public async Task<Client> GetByIdAsync(long id)
    {
        var client = await _repository.GetByIdAsync(id);
        if (client == null) throw new KeyNotFoundException($"Client with ID {id} not found.");
        return client;
    }

    public async Task<Client> UpdateAsync(Client entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        return await _repository.UpdateAsync(entity);
    }

    public async Task UpdateRangeAsync(IEnumerable<Client> entities)
    {
        if (entities == null) throw new ArgumentException("Entities cannot be null or empty.");
        await _repository.UpdateRangeAsync(entities);
    }
}




using CakeShopProject.Domain.Entities;
using CakeShopProject.Domain.Interface.Repository;
using CakeShopProject.Domain.Interface.Service;
using System.Linq.Expressions;

namespace CakeShopProject.Service.Services;

public class OrdersService : IOrdersService
{
    private readonly IOrdersRepository _ordersRepository;
    public OrdersService(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public async Task<Orders> AddAsync(Orders entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        return await _ordersRepository.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<Orders> entities)
    {
        if (entities == null || entities.Count == 0) throw new ArgumentException("Entities cannot be null or empty.");
        await _ordersRepository.AddRangeAsync(entities);
    }

    public async Task DeleteAsync(Orders entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        await _ordersRepository.DeleteAsync(entity);
    }

    public async Task<Orders> DeletedAsync(long id)
    {
        var order = await _ordersRepository.GetByIdAsync(id);
        if (order == null) throw new KeyNotFoundException($"Order with ID {id} not found.");
        return await _ordersRepository.DeletedAsync(id);
    }

    public async Task<IEnumerable<Orders>> GetAllAsync(Expression<Func<Orders, bool>> predicate)
    {
        return await _ordersRepository.GetAllAsync(predicate);
    }

    public async Task<Orders> GetAsync(Expression<Func<Orders, bool>> predicate)
    {
        return await _ordersRepository.GetAsync(predicate);
    }

    public async Task<Orders> GetByIdAsync(long id)
    {
        var order = await _ordersRepository.GetByIdAsync(id);
        if (order == null) throw new KeyNotFoundException($"Order with ID {id} not found.");
        return order;
    }

    public async Task<Orders> UpdateAsync(Orders entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        return await _ordersRepository.UpdateAsync(entity);
    }

    public async Task UpdateRangeAsync(IEnumerable<Orders> entities)
    {
        if (entities == null || !entities.Any()) throw new ArgumentException("Entities cannot be null or empty.");
        await _ordersRepository.UpdateRangeAsync(entities);
    }
}


using CakeShopProject.Domain.Entities;
using CakeShopProject.Domain.Interface.Repository;
using CakeShopProject.Domain.Interface.Service;
using System.Linq.Expressions;

namespace CakeShopProject.Service.Services;

public class StateService : IStateService
{
    private readonly IStateRepository _stateRepository;

    public StateService(IStateRepository stateRepository)
    {
        _stateRepository = stateRepository;
    }

    public async Task<State> AddAsync(State entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        return await _stateRepository.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<State> entities)
    {
        if (entities == null || entities.Count == 0) throw new ArgumentException("Entities cannot be null or empty.");
        await _stateRepository.AddRangeAsync(entities);
    }

    public async Task DeleteAsync(State entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        await _stateRepository.DeleteAsync(entity);
    }

    public async Task<State> DeletedAsync(long id)
    {
        var state = await _stateRepository.GetByIdAsync(id);
        if (state == null) throw new KeyNotFoundException($"State with ID {id} not found.");
        return await _stateRepository.DeletedAsync(id);
    }

    public async Task<IEnumerable<State>> GetAllAsync(Expression<Func<State, bool>> predicate)
    {
        return await _stateRepository.GetAllAsync(predicate);
    }

    public async Task<State> GetAsync(Expression<Func<State, bool>> predicate)
    {
        return await _stateRepository.GetAsync(predicate);
    }

    public async Task<State> GetByIdAsync(long id)
    {
        var state = await _stateRepository.GetByIdAsync(id);
        if (state == null) throw new KeyNotFoundException($"State with ID {id} not found.");
        return state;
    }

    public async Task<State> UpdateAsync(State entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        return await _stateRepository.UpdateAsync(entity);
    }

    public async Task UpdateRangeAsync(IEnumerable<State> entities)
    {
        if (entities == null || !entities.Any()) throw new ArgumentException("Entities cannot be null or empty.");
        await _stateRepository.UpdateRangeAsync(entities);
    }
}



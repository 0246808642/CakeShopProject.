using CakeShopProject.Domain.Entities;
using CakeShopProject.Domain.Interface.Repository;
using CakeShopProject.Domain.Interface.Service;
using System.Linq.Expressions;

namespace CakeShopProject.Service.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _repository;

    public CityService(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<City> AddAsync(City entity)
    {
        return await _repository.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<City> entity)
    {
       await _repository.AddRangeAsync(entity);
    }

    public Task DeleteAsync(City entity)
    {
        return _repository.DeleteAsync(entity);
    }

    public async Task<City> DeletedAsync(long id)
    {
       var find = await _repository.GetByIdAsync(id);

        if (find == null)
        {
            throw new Exception($"City with ID {id} not found.");
        }
        await _repository.DeleteAsync(find);

        return find;
    }

    public async Task<IEnumerable<City>> GetAllAsync(Expression<Func<City, bool>> predicate)
    {
       return await _repository.GetAllAsync(predicate);
    }

    public Task<City> GetAsync(Expression<Func<City, bool>> predicate)
    {
      return _repository.GetAsync(predicate);
    }

    public Task<City> GetByIdAsync(long id)
    {
      var city = _repository.GetByIdAsync(id);
      if (city == null)
        {
            throw new Exception($"City {id} does not exist");
        }
      return city;
    }

    public Task<City> UpdateAsync(City entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateRangeAsync(IEnumerable<City> entity)
    {
        throw new NotImplementedException();
    }
}

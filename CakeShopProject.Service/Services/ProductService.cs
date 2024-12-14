using CakeShopProject.Domain.Entities;
using CakeShopProject.Domain.Interface.Repository;
using CakeShopProject.Domain.Interface.Service;
using System.Linq.Expressions;

namespace CakeShopProject.Service.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> AddAsync(Product entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        return await _productRepository.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<Product> entities)
    {
        if (entities == null || entities.Count == 0) throw new ArgumentException("Entities cannot be null or empty.");
        await _productRepository.AddRangeAsync(entities);
    }

    public async Task DeleteAsync(Product entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        await _productRepository.DeleteAsync(entity);
    }

    public async Task<Product> DeletedAsync(long id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) throw new KeyNotFoundException($"Product with ID {id} not found.");
        return await _productRepository.DeletedAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>> predicate)
    {
        return await _productRepository.GetAllAsync(predicate);
    }

    public async Task<Product> GetAsync(Expression<Func<Product, bool>> predicate)
    {
        return await _productRepository.GetAsync(predicate);
    }

    public async Task<Product> GetByIdAsync(long id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) throw new KeyNotFoundException($"Product with ID {id} not found.");
        return product;
    }

    public async Task<Product> UpdateAsync(Product entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        return await _productRepository.UpdateAsync(entity);
    }

    public async Task UpdateRangeAsync(IEnumerable<Product> entities)
    {
        if (entities == null || !entities.Any()) throw new ArgumentException("Entities cannot be null or empty.");
        await _productRepository.UpdateRangeAsync(entities);
    }

}


using CakeShopProject.Domain.Entities;
using CakeShopProject.Domain.Enum;
using CakeShopProject.Domain.Interface.Repository;
using CakeShopProject.Domain.Interface.Service;
using FluentValidation;
using CakeShopProject.Shared.Helpers;
using System.Linq.Expressions;
using ValidationFailure = FluentValidation.Results.ValidationFailure;

namespace CakeShopProject.Service.Services;

public class ClientService : IClientService
{
    private readonly IValidator<Client> _vValidator;
    private readonly IClientRepository _repository;

    public ClientService(IClientRepository repository, IValidator<Client> Validator)
    {
        _repository = repository;
        _vValidator = Validator;
    }

    public async Task<Client> AddAsync(Client entity)
    {
        _ = entity ?? throw new ArgumentNullException(nameof(entity));

        var listErrors = await ValidateClient(entity);

        if (listErrors.Any())
            throw new ValidationException(listErrors);

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
    public async Task<List<ValidationFailure>> ValidateClient(Client entity)
    {
        var listErrors = new List<ValidationFailure>();

        var validation = _vValidator.Validate(entity);

        if (!validation.IsValid)
            listErrors.AddRange(validation.Errors);

        var isValidateEmail = await GetAsync(x => x.Email.RemoveSpace() == entity.Email.RemoveSpace() && x.Situation == Situation.Active || x.Email.RemoveSpace() == entity.Email.RemoveSpace() && x.Situation == Situation.Inactive);
        if (isValidateEmail is { } && isValidateEmail.Id > 0)
            listErrors.Add(new ValidationFailure("Client", $"Já existe um email {(isValidateEmail.Situation == Situation.Active ? " ativo " : " inativo ")} cadastrado para esse cliente."));

        var isValidateCpf = await GetAsync(x => x.Cpf.RemoveScore() == entity.Cpf.RemoveScore() && x.Situation == Situation.Active || x.Email.RemoveScore() == entity.Cpf.RemoveScore() && x.Situation == Situation.Inactive);
        if (isValidateCpf is { } && isValidateCpf.Id > 0)
            listErrors.Add(new ValidationFailure("Client", $"Já existe um cpf {(isValidateCpf.Situation == Situation.Active ? " ativo " : " inativo ")} cadastrado para esse cliente."));

        return listErrors;
    }

    Task<List<Microsoft.IdentityModel.Tokens.ValidationFailure>> IClientService.ValidateClient(Client entity)
    {
        throw new NotImplementedException();
    }
}




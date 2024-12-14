using CakeShopProject.Domain.Entities.Base;

namespace CakeShopProject.Domain.Entities;
/// <summary>
/// Cliente
/// </summary>
public class Client : EntityBase
{
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
    public DateTime DataOfBirth { get; set; }
    public string Cpf { get; set; }
    public string Address { get; set; }
    public string NumberOfHouse { get; set; }
    public string ZipCode { get; set; }

    // Relacionamento
    public virtual ICollection<Orders> Orders { get; set; }
    public long CityId { get; set; }
    public City City { get; set; }
}


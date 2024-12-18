using CakeShopProject.Domain.Entities.Base;

namespace CakeShopProject.Domain.Entities;
/// <summary>
/// Cidade
/// </summary>
public class City : EntityBase
{
    public string Name { get; set; }
    public string CodeCity { get; set; }

    // Relacionamento
    public virtual ICollection<Client> Client { get; set; }
    public long StateId { get; set; }
    public State State { get; set; }

}

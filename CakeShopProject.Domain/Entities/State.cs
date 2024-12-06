using CakeShopProject.Domain.Entities.Base;

namespace CakeShopProject.Domain.Entities;
/// <summary>
/// Estado
/// </summary>
public  class State : EntityBase
{
    public string Name { get; set; }
    public string Uf { get; set; }

    // Relacionamento
    public virtual ICollection<City> City { get; set; }
   
}

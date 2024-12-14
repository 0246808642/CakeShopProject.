namespace CakeShopProject.Domain.Entities.Dtos.City;

public class CityUpdateRequestDto
{
    public string Nome { get; set; }
    public string CodeCity  { get; set; }
    public long StateId { get; set; }
    public bool IsValidated { get; set; }

}

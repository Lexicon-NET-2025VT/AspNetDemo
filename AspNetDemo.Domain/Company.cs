using System.ComponentModel.DataAnnotations;

namespace AspNetDemo.Domain;

public class Company
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string City { get; set; } = null!;
    //public string? StreetAddress { get; set; } = null!;
    public List<Order> Orders { get; set; } = null!;
}

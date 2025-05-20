using System.ComponentModel.DataAnnotations;

namespace AspNetDemo.Web.Models;

public class Company
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public string City { get; set; } = null!;
}
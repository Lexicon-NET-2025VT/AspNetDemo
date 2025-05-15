using System.ComponentModel.DataAnnotations;

namespace AspNetDemo.Web.Models;

public class Company
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Enter a name")]
    [Display(Name = "Name", Prompt = "Name")]
    public string CompanyName { get; set; } = null!;

    [Required(ErrorMessage = "Enter a city")]
    [Display(Name = "City", Prompt = "City")]
    public string City { get; set; } = null!;
}

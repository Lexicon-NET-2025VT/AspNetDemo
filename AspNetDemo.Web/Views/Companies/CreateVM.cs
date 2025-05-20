using System.ComponentModel.DataAnnotations;

namespace AspNetDemo.Web.Views.Companies;

public class CreateVM
{
    [Required(ErrorMessage = "Enter a name")]
    [Display(Name = "Name", Prompt = "Name")]
    public required string CompanyName { get; set; }

    [Required(ErrorMessage = "Enter a city")]
    [Display(Name = "City", Prompt = "City")]
    public required string City { get; set; }
}

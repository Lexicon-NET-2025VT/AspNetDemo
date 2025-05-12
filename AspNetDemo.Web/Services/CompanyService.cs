using AspNetDemo.Web.Models;

namespace AspNetDemo.Web.Services;

public class CompanyService
{
    List<Company> companies = [
        new Company { Id = 1, Name = "Ica" },
        new Company { Id = 2, Name = "Coop" },
        new Company { Id = 3, Name = "Hemköp" },
        ];

    public Company[] GetAll() => companies
        .OrderBy(o => o.Name)
        .ToArray();

    public Company? GetById(int id) => companies
        .SingleOrDefault(o => o.Id == id);
}

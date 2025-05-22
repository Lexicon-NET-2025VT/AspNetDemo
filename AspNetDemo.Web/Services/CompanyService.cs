using AspNetDemo.Web.Models;

namespace AspNetDemo.Web.Services;

public class CompanyService
{
    List<Company> companies = [
        new Company { Id = 42, CompanyName = "Ica", City = "Stockholm" },
        new Company { Id = 21, CompanyName = "Coop", City = "Stockholm" },
        new Company { Id = 34, CompanyName = "Hemköp", City = "Göteborg" },
        ];

    public Company[] GetAll() => companies
        .OrderBy(o => o.CompanyName)
        .ToArray();

    public Company? GetById(int id) => companies
        .SingleOrDefault(o => o.Id == id);

    public async Task AddAsync(Company company)
    {
        company.Id = companies.Max(o => o.Id) + 1;
        companies.Add(company);
        await Task.Delay(1000);
    }
}

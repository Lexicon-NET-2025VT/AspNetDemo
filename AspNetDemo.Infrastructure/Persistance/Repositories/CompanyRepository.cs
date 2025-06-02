
using AspNetDemo.Application.Companies;
using AspNetDemo.Domain;
using AspNetDemo.Infrastructure.Persistance;

namespace AspNetDemo.Persistance.Repositories;

public class CompanyRepository(ApplicationContext context) : ICompanyRepository
{
    public Company[] GetAll() => context.Companies
        .ToArray();

    public Company? GetById(int id) => context.Companies
        .Find(id);

    public async Task AddAsync(Company company)
    {
        context.Companies.Add(company);
        await context.SaveChangesAsync();
    }
}

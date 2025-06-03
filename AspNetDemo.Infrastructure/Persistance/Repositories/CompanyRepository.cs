
using AspNetDemo.Application.Companies;
using AspNetDemo.Domain;
using AspNetDemo.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace AspNetDemo.Persistance.Repositories;

public class CompanyRepository(ApplicationContext context) : ICompanyRepository
{
    public async Task<Company[]> GetAllAsync(bool includeOrders)
    {
        var query = context.Companies
            .AsNoTracking();

        if (includeOrders)
            query = query.Include(c => c.Orders);

        return await query.ToArrayAsync();
    }

    public async Task<Company?> GetByIdAsync(int id) =>
        await context.Companies.FindAsync(id);

    public async Task AddAsync(Company company)
    {
        context.Companies.Add(company);
        await context.SaveChangesAsync();
    }
}

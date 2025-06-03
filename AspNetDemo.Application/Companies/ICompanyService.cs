using AspNetDemo.Domain;

namespace AspNetDemo.Application.Companies;

public interface ICompanyService
{
    Task AddAsync(Company company);
    Task<Company[]> GetAllAsync();
    Task<Company?> GetByIdAsync(int id);
}
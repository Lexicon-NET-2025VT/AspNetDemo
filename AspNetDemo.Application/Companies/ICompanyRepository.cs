using AspNetDemo.Domain;

namespace AspNetDemo.Application.Companies;

public interface ICompanyRepository
{
    void Add(Company company);
    Task<Company[]> GetAllAsync(bool includeOrders = false);
    Task<Company?> GetByIdAsync(int id);
}

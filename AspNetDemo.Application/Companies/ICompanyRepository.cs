using AspNetDemo.Domain;

namespace AspNetDemo.Application.Companies;

public interface ICompanyRepository
{
    Task AddAsync(Company company);
    Company[] GetAll();
    Company? GetById(int id);
}
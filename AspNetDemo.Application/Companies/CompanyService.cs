using AspNetDemo.Domain;

namespace AspNetDemo.Application.Companies;

public class CompanyService(ICompanyRepository companyRepository) : ICompanyService
{
    public Company[] GetAll()
    {
        return companyRepository
            .GetAll()
            .OrderBy(o => o.CompanyName)
            .ToArray();
    }

    public Company? GetById(int id)
    {
        if (id <= 0)
            throw new ArgumentException($@"Id must be a positive value", nameof(id));

        var ret = companyRepository.GetById(id);

        if (ret == null)
            throw new Exception($@"Unable to find company with {nameof(Company.Id)} {id}");

        return ret;
    }

    public async Task AddAsync(Company company)
    {
        if (company == null)
            throw new ArgumentException($@"{nameof(company)} must not be null", nameof(company));
        
        // Capitalize first letter
        company.CompanyName = char.ToUpper(company.CompanyName[0]) + company.CompanyName.Substring(1);
        
        await companyRepository.AddAsync(company);
    }
}

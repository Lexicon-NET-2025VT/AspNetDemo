using AspNetDemo.Domain;

namespace AspNetDemo.Application.Companies;

public class CompanyService(IUnitOfWork unitOfWork) : ICompanyService
{
    public async Task<Company[]> GetAllAsync(bool includeOrders)
    {
        return (await unitOfWork.Companies
            .GetAllAsync(includeOrders))
            .OrderBy(o => o.CompanyName)
            .ToArray();
    }

    public async Task<Company?> GetByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException($@"Id must be a positive value", nameof(id));

        var ret = await unitOfWork.Companies.GetByIdAsync(id);

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

        unitOfWork.Companies.Add(company);
        await unitOfWork.PersistAllAsync();
    }
}

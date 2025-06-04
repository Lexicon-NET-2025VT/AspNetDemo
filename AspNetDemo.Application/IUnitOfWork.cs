using AspNetDemo.Application.Companies;

namespace AspNetDemo.Application;
public interface IUnitOfWork
{
    ICompanyRepository Companies { get; }
    IOrderRepository Orders { get; }
    Task PersistAllAsync();
}
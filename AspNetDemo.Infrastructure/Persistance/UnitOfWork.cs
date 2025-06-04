using AspNetDemo.Application;
using AspNetDemo.Application.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDemo.Infrastructure.Persistance;
public class UnitOfWork(
    ApplicationContext context,
    ICompanyRepository companyRepository,
    IOrderRepository orderRepository) : IUnitOfWork
{
    public ICompanyRepository Companies => companyRepository;
    public IOrderRepository Orders => orderRepository;

    public async Task PersistAllAsync() => await context.SaveChangesAsync();
}


using AspNetDemo.Application.Companies;
using AspNetDemo.Domain;
using AspNetDemo.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace AspNetDemo.Persistance.Repositories;

public class OrderRepository(ApplicationContext context) : IOrderRepository
{
    public async Task<Order[]> GetAllAsync() => await context.Orders.ToArrayAsync();
    public async Task<Order?> GetByIdAsync(int id) => await context.Orders.FindAsync(id);
    public void Add(Order order) => context.Orders.Add(order);
}

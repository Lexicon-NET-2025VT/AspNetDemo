using AspNetDemo.Domain;

namespace AspNetDemo.Application.Companies;

public interface IOrderRepository
{
    void Add(Order order);
    Task<Order[]> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
}
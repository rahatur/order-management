using OrderManagement.Server.Models;

namespace OrderManagement.Server.Services
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order order);

        Task<bool> UpdateOrder(int id, Order order);

        Task<bool> DeleteOrder(int id);

        Task<List<Order>> GetAllOrders();

        Task<Order> GetOrder(int id);
    }
}

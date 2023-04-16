using OrderManagement.Server.Models;
using OrderManagement.Server.Repository;

namespace OrderManagement.Server.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _order;
        public OrderService(IRepository<Order> order)
        {
            _order = order;
        }
        public async Task<Order> AddOrder(Order order)
        {
            return await _order.CreateAsync(order);
        }

        public async Task<bool> UpdateOrder(int id, Order order) 
        {
            var data = await _order.GetByIdAsync(order.Id);

            if (data != null)
            {
                data.Name = order.Name;
                data.State = order.State;

                await _order.UpdateAsync(data);
                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            await _order.DeleteAsync(id);
            return true;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _order.GetAllAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _order.GetByIdAsync(id);
        }
    }
}

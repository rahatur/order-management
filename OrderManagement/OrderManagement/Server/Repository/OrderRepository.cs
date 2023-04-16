using OrderManagement.Server.AppDbContext;
using OrderManagement.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Server.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        ApplicationDbContext _dbContext;
        public OrderRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Order> CreateAsync(Order _object)
        {
            var obj = await _dbContext.Orders.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public async Task UpdateAsync(Order _object)
        {
            _dbContext.Orders.Update(_object);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int Id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);   
        }

        public async Task DeleteAsync(int id)
        {
            var data = _dbContext.Orders.FirstOrDefault(x=>x.Id == id);
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}

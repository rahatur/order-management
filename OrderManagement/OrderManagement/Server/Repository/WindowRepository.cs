using OrderManagement.Server.AppDbContext;
using OrderManagement.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Server.Repository
{
    public class WindowRepository : IRepository<Window>
    {
        ApplicationDbContext _dbContext;
        public WindowRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Window> CreateAsync(Window _object)
        {
            var obj = await _dbContext.Windows.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public async Task UpdateAsync(Window _object)
        {
            _dbContext.Windows.Update(_object);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Window>> GetAllAsync()
        {
            return await _dbContext.Windows.ToListAsync();
        }

        public async Task<Window> GetByIdAsync(int Id)
        {
            return await _dbContext.Windows.FirstOrDefaultAsync(x => x.Id == Id);   
        }

        public async Task DeleteAsync(int id)
        {
            var data = _dbContext.Windows.FirstOrDefault(x=>x.Id == id);
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}

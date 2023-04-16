using OrderManagement.Server.AppDbContext;
using OrderManagement.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Server.Repository
{
    public class SubelementRepository : IRepository<Subelement>
    {
        ApplicationDbContext _dbContext;
        public SubelementRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Subelement> CreateAsync(Subelement _object)
        {
            var obj = await _dbContext.Subelements.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public async Task UpdateAsync(Subelement _object)
        {
            _dbContext.Subelements.Update(_object);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Subelement>> GetAllAsync()
        {
            return await _dbContext.Subelements.ToListAsync();
        }

        public async Task<Subelement> GetByIdAsync(int Id)
        {
            return await _dbContext.Subelements.FirstOrDefaultAsync(x => x.Id == Id);   
        }

        public async Task DeleteAsync(int id)
        {
            var data = _dbContext.Subelements.FirstOrDefault(x=>x.Id == id);
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}

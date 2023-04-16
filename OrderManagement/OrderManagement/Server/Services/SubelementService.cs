using OrderManagement.Server.Models;
using OrderManagement.Server.Repository;

namespace OrderManagement.Server.Services
{
    public class SubelementService : ISubelementService
    {
        private readonly IRepository<Subelement> _subelement;
        public SubelementService(IRepository<Subelement> subelement)
        {
            _subelement = subelement;
        }
        public async Task<Subelement> AddSubelement(Subelement subelement)
        {
            return await _subelement.CreateAsync(subelement);
        }

        public async Task<bool> UpdateSubelement(int id, Subelement subelement) 
        {
            var data = await _subelement.GetByIdAsync(id);

            if (data != null)
            {
                data.WindowId = subelement.WindowId;
                data.Type = subelement.Type;
                data.Width = subelement.Width;
                data.Height = subelement.Height;

                await _subelement.UpdateAsync(data);
                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteSubelement(int id)
        {
            await _subelement.DeleteAsync(id);
            return true;
        }

        public async Task<List<Subelement>> GetAllSubelements(int windowId)
        {
            //return await _subelement.GetAllAsync();
            var subelements = await _subelement.GetAllAsync();
            return subelements.Where(s => s.WindowId == windowId).ToList();
        }

        public async Task<Subelement> GetSubelement(int id)
        {
            return await _subelement.GetByIdAsync(id);
        }
    }
}

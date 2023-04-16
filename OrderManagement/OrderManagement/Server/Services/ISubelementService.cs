using OrderManagement.Server.Models;

namespace OrderManagement.Server.Services
{
    public interface ISubelementService
    {
        Task<Subelement> AddSubelement(Subelement subelement);

        Task<bool> UpdateSubelement(int id, Subelement subelement);

        Task<bool> DeleteSubelement(int id);

        Task<List<Subelement>> GetAllSubelements();

        Task<Subelement> GetSubelement(int id);
    }
}

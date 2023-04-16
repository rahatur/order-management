using OrderManagement.Server.Models;

namespace OrderManagement.Server.Services
{
    public interface IWindowService
    {
        Task<Window> AddWindow(Window window);

        Task<bool> UpdateWindow(int id, Window window);

        Task<bool> DeleteWindow(int id);

        Task<List<Window>> GetAllWindows();

        Task<Window> GetWindow(int id);
    }
}

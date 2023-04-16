using OrderManagement.Server.Models;
using OrderManagement.Server.Repository;
using System.Collections.Generic;

namespace OrderManagement.Server.Services
{
    public class WindowService : IWindowService
    {
        private readonly IRepository<Window> _window;
        public WindowService(IRepository<Window> window)
        {
            _window = window;
        }
        public async Task<Window> AddWindow(Window window)
        {
            return await _window.CreateAsync(window);
        }

        public async Task<bool> UpdateWindow(int id, Window window) 
        {
            var data = await _window.GetByIdAsync(id);

            if (data != null)
            {
                data.OrderId = window.OrderId;
                data.Name = window.Name;
                data.Quantity = window.Quantity;

                await _window.UpdateAsync(data);
                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteWindow(int id)
        {
            await _window.DeleteAsync(id);
            return true;
        }

        public async Task<List<Window>> GetAllWindows(int orderId)
        {
            //return await _window.GetAllAsync();
            var windows = await _window.GetAllAsync();
            return windows.Where(w => w.OrderId == orderId).ToList();
        }

        public async Task<Window> GetWindow(int id)
        {
            return await _window.GetByIdAsync(id);
        }
    }
}

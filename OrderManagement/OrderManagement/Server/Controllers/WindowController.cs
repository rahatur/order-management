using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OrderManagement.Server.Models;
using OrderManagement.Server.Services;
using OrderManagement.Shared;
using System;

namespace OrderManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        private readonly IWindowService _windowService;
        public WindowController(IWindowService windowService)
        {
            _windowService = windowService;
        }

        [HttpGet]
        public async Task<List<Window>> GetAll()
        {
            return await _windowService.GetAllWindows();
        }

        [HttpGet("{id}")]
        public async Task<Window> Get(int id)
        {
            return await _windowService.GetWindow(id);
        }

        [HttpPost]
        public async Task<Window> AddWindow([FromBody] WindowAddModel model)
        {
            //TODO: Refactor - Use Automapper to map objects
            Window window = new Window()
            {
                OrderId = model.OrderId,
                Name = model.Name,
                Quantity = model.Quantity
            };

            return await _windowService.AddWindow(window);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteWindow(int id)
        {
            return await _windowService.DeleteWindow(id);
        }

        
        [HttpPut("{id}")]
        public async Task<bool> UpdateWindow([FromBody] WindowUpdateModel model)
        {
            //TODO: Refactor - Use Automapper to map objects
            Window window = new Window()
            {
                Id = model.Id,
                OrderId = model.OrderId,
                Name = model.Name,
                Quantity = model.Quantity
            };

            return await _windowService.UpdateWindow(0, window);
        }
    }
}

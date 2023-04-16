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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<List<Order>> GetAll()
        {
            return await _orderService.GetAllOrders();
        }

        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            return await _orderService.GetOrder(id);
        }

        [HttpPost]
        public async Task<Order> AddOrder([FromBody] OrderAddModel model)
        {
            //TODO: Refactor - Use Automapper to map objects
            Order order = new Order()
            {
                Name = model.Name,
                State = model.State
            };

            return await _orderService.AddOrder(order);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteOrder(int id)
        {
            return await _orderService.DeleteOrder(id);
        }

        
        [HttpPut("{id}")]
        public async Task<bool> UpdateOrder([FromBody] OrderUpdateModel model)
        {
            //TODO: Refactor - Use Automapper to map objects
            Order order = new Order()
            {
                Id = model.Id,
                Name = model.Name,
                State = model.State
            };

            return await _orderService.UpdateOrder(0, order);
        }
    }
}

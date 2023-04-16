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
    public class SubelementController : ControllerBase
    {
        private readonly ISubelementService _subelementService;
        public SubelementController(ISubelementService subelementService)
        {
            _subelementService = subelementService;
        }

        [HttpGet("{id}")]
        public async Task<List<Subelement>> GetAll(int id)
        {
            //Load by WindowId
            return await _subelementService.GetAllSubelements(id);
        }

        [HttpPost]
        public async Task<Subelement> AddSubelement([FromBody] SubelementAddModel model)
        {
            //TODO: Refactor - Use Automapper to map objects
            Subelement subelement = new Subelement()
            {
                WindowId = model.WindowId,
                Type = model.Type,
                Width = model.Width,
                Height = model.Height
            };

            return await _subelementService.AddSubelement(subelement);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteSubelement(int id)
        {
            return await _subelementService.DeleteSubelement(id);
        }

        
        [HttpPut("{id}")]
        public async Task<bool> UpdateSubelement([FromBody] SubelementUpdateModel model)
        {
            //TODO: Refactor - Use Automapper to map objects
            Subelement subelement = new Subelement()
            {
                Id = model.Id,
                WindowId = model.WindowId,
                Type = model.Type,
                Width = model.Width,
                Height = model.Height
            };

            return await _subelementService.UpdateSubelement(0, subelement);
        }
    }
}

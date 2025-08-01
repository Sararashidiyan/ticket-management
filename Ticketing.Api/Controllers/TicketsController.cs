using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Application.Contract.Tickets.DTOs;
using Ticketing.Application.Contract.Tickets.Services;

namespace Ticketing.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        #region Admin
        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}")]
        public async Task Update(Guid id)
        {
            await _ticketService.Update(id);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet()]
        public async Task<List<TicketDTO>> GetAll()
        {
            return await _ticketService.GetAll();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("status")]
        public async Task<List<TicketDTO>> GetByStatus(string status)
        {
            return await _ticketService.GetByStatus(status);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<TicketDTO> GetById(Guid id)
        {
            return await _ticketService.GetById(id);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _ticketService.Delete(id);
        }
        #endregion


        #region Employee
        [Authorize(Roles = "Employee")]
        [HttpPost()]
        public async Task Create([FromBody] CreateTicketDTO item)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _ticketService.Create(item);
        }
        [Authorize(Roles = "Employee")]
        [HttpGet("my")]
        public async Task<List<TicketDTO>> GetEmployeeTickets()
        {
            return await _ticketService.GetEmployeeTickets();
        }
        [Authorize(Roles = "Employee")]
        [HttpGet("{id}/my")]
        public async Task<TicketDTO> GetEmployeeTicketById([FromRoute] Guid id)
        {
            return await _ticketService.GetEmployeeTicketById(id);
        }
        #endregion
    }
}

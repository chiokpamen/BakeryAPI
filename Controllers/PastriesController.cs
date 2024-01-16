using BakeryAPI.Models;
using BakeryAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace BakeryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PastriesController : ControllerBase
    {
        private readonly IBakeryRepository _bakeryRepository;

        public PastriesController(IBakeryRepository bakeryRepository)
        {
            _bakeryRepository = bakeryRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Pastry>> GetPastries()
        {
            return await _bakeryRepository.Get();
        }
        [HttpGet("{PastryId}")]
        public async Task<ActionResult<Pastry>> GetPastries(int PastryId)
        {
            if (PastryId <= 0)
            {
                return BadRequest("Negative value");
            }
          
            return await _bakeryRepository.Get(PastryId);
        }
       
        [HttpPost]
        public async Task<ActionResult<Pastry>> PostPastries([FromBody] Pastry pastry)
        {
            var newPastry = await _bakeryRepository.Create(pastry);
            return CreatedAtAction(nameof(GetPastries), new { PastryId = newPastry }, newPastry);
        }
        [HttpPut]
        public async Task<ActionResult> PutPastries(int PastryId, [FromBody] Pastry pastry)
        {
            if (PastryId != pastry.PastryId)
            {
                return BadRequest();
            }
            await _bakeryRepository.Update(pastry);
            return NoContent();
            
        }
        [HttpDelete("{PastryId}")]
        public async Task<ActionResult> Delete(int PastryId)
        {
            var pastryToDelete = await _bakeryRepository.Get(PastryId);
            if (pastryToDelete == null) 
                return NotFound();

            await _bakeryRepository.Delete(pastryToDelete.PastryId);
            return NoContent();
        }
    }
}

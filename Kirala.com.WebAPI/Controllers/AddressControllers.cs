using Kirala.com.Business.Abstract;
using Kirala.com.Entities.Dto_s.Address;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;

namespace Kirala.com.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressControllers : ControllerBase
    {
        IAddressManager _addressManager;
        public AddressControllers(IAddressManager addressManager)
        {
            _addressManager = addressManager;
        }

        [HttpPost]
        [Route("([Action])")]
        public async Task<IActionResult> Create([FromBody] AddressCreateDto addressCreateDto)
        {
            if (addressCreateDto != null)
                return Ok(await _addressManager.Create(addressCreateDto));
            return BadRequest();
        }

        [HttpPut]
        [Route("([Action])")]
        public async Task<IActionResult> Update(AddressUpdateDto addressUpdateDto)
        {
            if (addressUpdateDto != null)
                return Ok(await _addressManager.Update(addressUpdateDto));
            return NotFound();
        }

        [HttpDelete]
        [Route("([Action])")]
        public async Task<IActionResult> Delete(AddressDto addressDto)
        {
            if (addressDto != null)
                return Ok(await _addressManager.Delete(addressDto));
            return NotFound();
        }

        [HttpGet]
        [Route("([Action])")]
        public async Task<IActionResult> GetById(int id)
        {
            var address = await _addressManager.GetById(id);
            if (address != null)
                return Ok(address);
            return NotFound();
        }
    }
}

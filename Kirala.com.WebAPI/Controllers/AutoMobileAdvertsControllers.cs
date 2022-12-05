using Kirala.com.Business.Abstract;
using Kirala.com.Entities.Dto_s.AutoMobileAdverts;
using Microsoft.AspNetCore.Mvc;

namespace Kirala.com.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoMobileAdvertsControllers : ControllerBase
    {
        IAutoMobileAdvertsManager _autoMobileAdvertsManager;
        IAddressManager _addressManager;
        public AutoMobileAdvertsControllers(IAutoMobileAdvertsManager autoMobileAdvertsManager, IAddressManager addressManager)
        {
            _autoMobileAdvertsManager = autoMobileAdvertsManager;
            _addressManager = addressManager;
        }
        
        [HttpPost]
        [Route("([Action])")]
        public async Task<IActionResult> Create([FromBody] AutoMobileAdvertsCreateDto addApiData)
        {
            if (addApiData != null)
                return Ok(await _autoMobileAdvertsManager.Create(addApiData));
            return NotFound();
        }

        [HttpPut]
        [Route("([Action])")]
        public async Task<IActionResult> Update(AutoMobileAdvertsUpdateDto advertsUpdateDto)
        {
            if (advertsUpdateDto != null)
                return Ok(await _autoMobileAdvertsManager.Update(advertsUpdateDto));
            return NotFound();
        }

        [HttpDelete]
        [Route("([Action])")]
        public async Task<IActionResult> DeleteById(int id)
        {
            return Ok(await _autoMobileAdvertsManager.DeleteById(id));
        }

        [HttpDelete]
        [Route("([Action])")]
        public async Task<IActionResult> Delete(AutoMobileAdvertsDto autoMobileAdverts)
        {
            if (autoMobileAdverts != null)
                return Ok(await _autoMobileAdvertsManager.Delete(autoMobileAdverts));
            return NotFound();
        }

        [HttpGet]
        [Route("([Action])")]
        public async Task<IActionResult> GetById(int id)
        {
            var get = await _autoMobileAdvertsManager.GetById(id);
            if (get!=null)
                return Ok(get);
            return NotFound();
        }

        [HttpGet]
        [Route("([Action])")]
        public async Task<IActionResult> GetAll()
        {
            var autoMobiles = await _autoMobileAdvertsManager.GetAll();
            if (autoMobiles != null)
                return Ok(autoMobiles);
            return NotFound();
        }
    }
}

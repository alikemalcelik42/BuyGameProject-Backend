using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamerController : Controller
    {
        IGamerService _gamerService;

        public GamerController(IGamerService gamerService)
        {
            _gamerService = gamerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _gamerService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getgamerdetails")]
        public IActionResult GetGamerDetails()
        {
            var result = _gamerService.GetGamerDetails();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _gamerService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Gamer gamer)
        {
            var result = _gamerService.Add(gamer);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Gamer gamer)
        {
            var result = _gamerService.Update(gamer);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Gamer gamer)
        {
            var result = _gamerService.Delete(gamer);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}

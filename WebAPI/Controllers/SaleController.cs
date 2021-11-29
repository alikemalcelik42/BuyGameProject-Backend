using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : Controller
    {
        ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _saleService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _saleService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getallbygameid")]
        public IActionResult GetAllByGameId(int gameId)
        {
            var result = _saleService.GetAllByGameId(gameId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getallbygamerid")]
        public IActionResult GetAllByGamerId(int gamerId)
        {
            var result = _saleService.GetAllByGamerId(gamerId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getsaledetails")]
        public IActionResult GetSaleDetails()
        {
            var result = _saleService.GetSaleDetails();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Sale sale)
        {
            var result = _saleService.Add(sale);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("addwithcampaigns")]
        public IActionResult AddWithCampaigns(Sale sale)
        {
            var result = _saleService.AddWithCampaigns(sale);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Sale sale)
        {
            var result = _saleService.Update(sale);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Sale sale)
        {
            var result = _saleService.Delete(sale);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiNet5.Data;
using WebApiNet5.Services;

namespace WebApiNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IhangHoaReponsitory _ihangHoaReponsitory;

        public ProductsController(IhangHoaReponsitory ihangHoaReponsitory) {
             _ihangHoaReponsitory = ihangHoaReponsitory;
        }

        [HttpGet]
        public IActionResult GetAllProduct(string search)
        {
            try
            {
                var result = _ihangHoaReponsitory.GetAll(search);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can't the product. ");
            }
        }
    }
}

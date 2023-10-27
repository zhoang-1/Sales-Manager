using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiNet5.Data;
using WebApiNet5.Models;
using WebApiNet5.Services;

namespace WebApiNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiVMController : ControllerBase
    {
        private readonly IloaiReponsitory _iloaiReponsitory;

        public LoaiVMController(IloaiReponsitory iloaiReponsitory) 
        {
            _iloaiReponsitory = iloaiReponsitory;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_iloaiReponsitory.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet ("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _iloaiReponsitory.GetById(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update (int id, LoaiVM loai)
        {
            if (id != loai.MaLoai)
            {
                return BadRequest();
            }
            try
            {
                _iloaiReponsitory.Update(loai);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _iloaiReponsitory.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Add (LoaiModels loai)
        {
            try
            {
                return Ok(_iloaiReponsitory.Add(loai));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

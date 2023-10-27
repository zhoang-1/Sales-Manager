using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApiNet5.Data;
using WebApiNet5.Models;

namespace WebApiNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDBContext _context;

        public LoaiController(MyDBContext context) { 
            _context = context;

        }
        [HttpGet]
        public IActionResult GetAll() {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }
        
        [HttpGet("{id}")]
        public IActionResult EditsByID(int id)
        {
            
                var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);

                if (loai == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(loai);
                }
            
        }
        

        [HttpPost]
        public IActionResult CreateNew (LoaiModels loaiModels) {

            try
            {
                var loai = new Loai
                {
                    TenLoai = loaiModels.TenLoai,
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult GetById(int id, LoaiModels loaiModels)
        {
            
                var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);

                if (loai == null)
                {
                    return NotFound();
                }
                else
                {
                    loai.TenLoai = loaiModels.TenLoai;
                    _context.SaveChanges();
                    return NoContent();
                }
            

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteByID(int id)
        {

            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);

            if (loai == null)
            {
                return NotFound();
            }
            else
            {
                _context.Loais.Remove(loai);
                _context.SaveChanges();
                return NoContent();
            }


        }



    }
}
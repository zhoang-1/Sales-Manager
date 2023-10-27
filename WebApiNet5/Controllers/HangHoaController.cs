using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WebApiNet5.Models;
using System.Linq;

namespace WebApiNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> HangHoas = new List<HangHoa>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(HangHoas);
        }


        [HttpGet("{id}")]

        public IActionResult GetById(String id)
        {
            try
            {
                var hangHoa = HangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hangHoa = new HangHoa()
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia

            };
            HangHoas.Add(hangHoa);
            return Ok(new
            {
                Succsess = true,
                data = hangHoa
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edits(String id, HangHoa HangHoaEdits)
        {
            try
            {
                var hangHoa = HangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                hangHoa.TenHangHoa = HangHoaEdits.TenHangHoa;
                hangHoa.DonGia = HangHoaEdits.DonGia;

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult remove(String id)
        {
            try
            {
                var hangHoa = HangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                HangHoas.Remove(hangHoa);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}


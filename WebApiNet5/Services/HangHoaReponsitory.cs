using System.Collections.Generic;
using System.Linq;
using WebApiNet5.Data;
using WebApiNet5.Models;

namespace WebApiNet5.Services
{
    public class HangHoaReponsitory : IhangHoaReponsitory
    {
        private MyDBContext _context;

        public HangHoaReponsitory(MyDBContext context)
        {
            _context = context;
        }
        public List<HangHoaModel> GetAll(string search)
        {
            var AllProduct = _context.HangHoas.Where(hh => hh.TenHh.Contains(search));

            var result = AllProduct.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.MaHh,
                TenHangHoa = hh.TenHh,
                DonGia = hh.DonGia,
                TenLoai = hh.Loai.TenLoai
            });
            return result.ToList();
        }
    }
}

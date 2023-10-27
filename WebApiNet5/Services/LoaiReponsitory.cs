using System.Collections.Generic;
using System.Linq;
using WebApiNet5.Data;
using WebApiNet5.Models;

namespace WebApiNet5.Services
{
    public class LoaiReponsitory : IloaiReponsitory
    {
        private MyDBContext _context;

        public LoaiReponsitory(MyDBContext context)
        {
            _context = context;
        }
        public LoaiVM Add(LoaiModels loaiModels)
        {
            var _loai = new Loai
            {
                TenLoai = loaiModels.TenLoai
            };
            _context.Add(_loai);
            _context.SaveChanges();
            return new LoaiVM
            {
                MaLoai = _loai.MaLoai,
                TenLoai = _loai.TenLoai

            };
        }

        public void Delete(int id)
        {
            var loai = _context.Loais.SingleOrDefault(Lo => Lo.MaLoai == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
            }
        }

        public List<LoaiVM> GetAll()
        {
            var loais = _context.Loais.Select(lo => new LoaiVM
            {
                MaLoai = lo.MaLoai,
                TenLoai = lo.TenLoai
            });
            return loais.ToList();

        }

        public LoaiVM GetById(int id)
        {
            
             var loai = _context.Loais.SingleOrDefault(Lo => Lo.MaLoai == id);
             if(loai != null)
              {
                return new LoaiVM
                {
                   MaLoai = loai.MaLoai,
                   TenLoai=loai.TenLoai
                };
              }
              return null;
                
           

        }

        public void Update(LoaiVM loai)
        {
            var _loai = _context.Loais.SingleOrDefault(Lo => Lo.MaLoai == loai.MaLoai);
            loai.TenLoai = loai.TenLoai;
            _context.SaveChanges();
        }
    }
}

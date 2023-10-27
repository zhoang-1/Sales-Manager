using System.Collections.Generic;
using System.Linq;
using WebApiNet5.Data;
using WebApiNet5.Models;

namespace WebApiNet5.Services
{
    public class LoaiReponsitoryInMemory : IloaiReponsitory
    {
        static List<LoaiVM> loais = new List<LoaiVM>
        {
            new LoaiVM{MaLoai =1, TenLoai = "Tivi"},
            new LoaiVM{MaLoai =2, TenLoai = "Tu Lanh"},
            new LoaiVM{MaLoai =3, TenLoai = "May Giat"},
            new LoaiVM{MaLoai =4, TenLoai = "Dieu hoa"}
        };
        public LoaiVM Add(LoaiModels loaiModels)
        {
            var _loai = new LoaiVM
            {
                
                MaLoai = loais.Max(lo => lo.MaLoai)+ 1,
                TenLoai = loaiModels.TenLoai
            };
           
            loais.Add(_loai); 
            return _loai;
            
        }

        public void Delete(int id)
        {
            var _loai = loais.SingleOrDefault(lo => lo.MaLoai == id);
            loais.Remove(_loai);
        }

        public List<LoaiVM> GetAll()
        {
            return loais;
        }

        public LoaiVM GetById(int id)
        {
            return loais.SingleOrDefault(lo => lo.MaLoai == id);
        }

        public void Update(LoaiVM loai)
        {
            var _loai  = loais.SingleOrDefault(lo => lo.MaLoai == loai.MaLoai);
            if (_loai != null)
            {
                _loai.TenLoai = loai.TenLoai;
            }
        }
    }
}

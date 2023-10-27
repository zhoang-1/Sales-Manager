

using System.Collections.Generic;
using WebApiNet5.Models;

namespace WebApiNet5.Services
{
    public interface IloaiReponsitory
    {
        List<LoaiVM> GetAll();
        LoaiVM GetById(int id);
        LoaiVM Add(LoaiModels loaiModels);
        void Update(LoaiVM loai);
        void Delete(int id);
        
    }
}

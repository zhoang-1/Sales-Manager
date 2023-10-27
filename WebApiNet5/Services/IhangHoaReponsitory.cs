using System.Collections.Generic;
using WebApiNet5.Data;
using WebApiNet5.Models;

namespace WebApiNet5.Services
{
    public interface IhangHoaReponsitory
    {
        List<HangHoaModel> GetAll(string search);
    }
}

using System;

namespace WebApiNet5.Models
{
    public class HangHoaVM //VM la view model ->dat ten 

    {
        public string TenHangHoa { get; set; }
        public double DonGia { get; set; }
    }
    public class HangHoa : HangHoaVM //VM la view model ->dat ten 

    {
        public Guid MaHangHoa { get; set; }
    }
    public class HangHoaModel
    {
        public Guid MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public double DonGia { get; set; }
        public string TenLoai { get; set; }
    }
}
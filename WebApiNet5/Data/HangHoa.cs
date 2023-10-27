using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace WebApiNet5.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid MaHh { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenHh { get; set; }
        public string MoTa { get; set; }
        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }

        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]

        public Loai Loai { get; set; }

        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public HangHoa()
        {
            ChiTietDonHangs = new List<ChiTietDonHang>();
        }
    }
}

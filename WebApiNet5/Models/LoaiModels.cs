using System.ComponentModel.DataAnnotations;

namespace WebApiNet5.Models
{
    public class LoaiModels
    {
        [Required]
        [MaxLength(100)]
        public string TenLoai { get; set; }
    }
}

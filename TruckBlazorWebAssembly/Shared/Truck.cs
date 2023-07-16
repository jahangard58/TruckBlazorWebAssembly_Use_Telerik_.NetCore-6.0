using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckBlazorWebAssembly.Shared
{
    public class Truck
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "وارد کردن مقدار الزامی میباشد")]
        [MaxLength(100, ErrorMessage = "بیش از مقدار مجاز وارد شده است")]
        public string? Title { get; set; }
        public string? Barcode { get; set; }
        public string? SmartCode { get; set; }
        public string? OwnerName { get; set; }
        public string? OwnerMobile { get; set; }
        public long? Carryingweight { get; set; }
    }
}

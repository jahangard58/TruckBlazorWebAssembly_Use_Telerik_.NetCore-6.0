using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckBlazorWebAssembly.Shared
{
    public class TruckViewModel
    {
        [Required]
        public string? Title { get; set; }
        public string? Barcode { get; set; }
        public string? SmartCode { get; set; }
        public string? OwnerName { get; set; }
        public string? OwnerMobile { get; set; }
        public long? Carryingweight { get; set; }
    }
}

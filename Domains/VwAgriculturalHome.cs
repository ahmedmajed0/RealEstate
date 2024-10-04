using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public partial class VwAgriculturalHome
    {
        public int Agrcultural_Id { get; set; }
        public string EstateTitle { get; set; } = null!;
        public decimal Price { get; set; }
        public int Area { get; set; }
        public int TowersNo { get; set; }
        public string? Location { get; set; }
        public string PurposeName { get; set; } = null!;
        public string ImageName { get; set; } = null!;
        public int? SubCla_Id { get; set; }
        public int? Purpose_Id { get; set; }
    }
}

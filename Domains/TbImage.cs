using System;
using System.Collections.Generic;

namespace Domains
{
    public partial class TbImage
    {
        public int ImgId { get; set; }
        public string? ImageName { get; set; }
        public int? ResidentialId { get; set; }
        public int? IndustrialId { get; set; }
        public int? CommercialId { get; set; }
        public int? AgrculturalId { get; set; }
    }
}

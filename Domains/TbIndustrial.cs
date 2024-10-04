using System;
using System.Collections.Generic;

namespace Domains
{
    public partial class TbIndustrial
    {
        public int IndustrialId { get; set; }
        public string EstateTitle { get; set; } = null!;
        public decimal Price { get; set; }
        public bool CarWorkshop { get; set; }
        public bool HeavyEquipment { get; set; }
        public bool Metalworks { get; set; }
        public bool Aluminum { get; set; }
        public bool Carpentry { get; set; }
        public int Area { get; set; }
        public string? Location { get; set; }
        public string Description { get; set; } = null!;
        public DateTime? DateOfPuplish { get; set; }
        public int? SubClaId { get; set; }
        public int? PurposeId { get; set; }
        public string? Video { get; set; }

        public virtual TbPurpose? Purpose { get; set; }
        public virtual TbSubClassification? SubCla { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Domains
{
    public partial class TbAgricultural
    {
        public int AgrculturalId { get; set; }
        public string EstateTitle { get; set; } = null!;
        public decimal Price { get; set; } 
        public int Area { get; set; }
        public string? Types { get; set; }
        public int TowersNo { get; set; }
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

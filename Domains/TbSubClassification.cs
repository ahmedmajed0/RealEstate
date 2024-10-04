using System;
using System.Collections.Generic;

namespace Domains
{
    public partial class TbSubClassification
    {
        public TbSubClassification()
        {
            TbAgriculturals = new HashSet<TbAgricultural>();
            TbCommercials = new HashSet<TbCommercial>();
            TbIndustrials = new HashSet<TbIndustrial>();
            TbResidentials = new HashSet<TbResidential>();
        }

        public int SubClaId { get; set; }
        public string Name { get; set; } = null!;
        public int? ClassificationId { get; set; }

        public virtual TbEstateClassification? Classification { get; set; }
        public virtual ICollection<TbAgricultural> TbAgriculturals { get; set; }
        public virtual ICollection<TbCommercial> TbCommercials { get; set; }
        public virtual ICollection<TbIndustrial> TbIndustrials { get; set; }
        public virtual ICollection<TbResidential> TbResidentials { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Domains
{
    public partial class TbPurpose
    {
        public TbPurpose()
        {
            TbAgriculturals = new HashSet<TbAgricultural>();
            TbCommercials = new HashSet<TbCommercial>();
            TbIndustrials = new HashSet<TbIndustrial>();
            TbResidentials = new HashSet<TbResidential>();
        }

        public int PurposeId { get; set; }
        public string PurposeName { get; set; } = null!;

        public virtual ICollection<TbAgricultural> TbAgriculturals { get; set; }
        public virtual ICollection<TbCommercial> TbCommercials { get; set; }
        public virtual ICollection<TbIndustrial> TbIndustrials { get; set; }
        public virtual ICollection<TbResidential> TbResidentials { get; set; }
    }
}

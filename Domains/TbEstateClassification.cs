using System;
using System.Collections.Generic;

namespace Domains
{
    public partial class TbEstateClassification
    {
        public TbEstateClassification()
        {
            TbSubClassifications = new HashSet<TbSubClassification>();
        }

        public int ClassificationId { get; set; }
        public string Classification { get; set; } = null!;

        public virtual ICollection<TbSubClassification> TbSubClassifications { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Domains
{
    public partial class VwAgricultural
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
        public string PurposeName { get; set; } = null!;
        public string Classification { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}

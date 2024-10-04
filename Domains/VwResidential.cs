using System;
using System.Collections.Generic;

namespace Domains
{
    public partial class VwResidential
    {
        public int ResidentialId { get; set; }
        public string EstateTitle { get; set; } = null!;
        public decimal Price { get; set; }
        public byte RoomsNo { get; set; }
        public byte Baths { get; set; }
        public byte HallsNo { get; set; }
        public bool StoreHouse { get; set; }
        public bool Roof { get; set; }
        public bool Yard { get; set; }
        public bool FinKitchen { get; set; }
        public string? Location { get; set; }
        public int Area { get; set; }
        public string Description { get; set; } = null!;
        public DateTime? DateOfPuplish { get; set; }
        public string PurposeName { get; set; } = null!;
        public string Classification { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}

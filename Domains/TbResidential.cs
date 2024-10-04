using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public partial class TbResidential
    {
        public int ResidentialId { get; set; }
        public string EstateTitle { get; set; } = null!;

        [Required (ErrorMessage = "من فضلك ادخل سعر العقار")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل عدد الغرف")]
        public byte RoomsNo { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل عدد دورات المياه")]
        public byte Baths { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل عدد الصالات")]
        public byte HallsNo { get; set; }
        public bool StoreHouse { get; set; }
        public bool Roof { get; set; }
        public bool Yard { get; set; }
        public bool FinKitchen { get; set; }
        public string? Location { get; set; } 
        public int Area { get; set; }
        [MaxLength(4000, ErrorMessage = "العدد المسموح به فقط هو 4000 حرف")]
        public string Description { get; set; } = null!;
        public DateTime? DateOfPuplish { get; set; }
        public int? SubClaId { get; set; }
        public int? PurposeId { get; set; }
        public string? Video { get; set; }

        public virtual TbPurpose? Purpose { get; set; }
        public virtual TbSubClassification? SubCla { get; set; }
    }
}

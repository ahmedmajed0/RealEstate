using Domains;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models
{
    public class HomePageVwModel
    {
        public HomePageVwModel()
        {
            listResidential = new List<VwResidentialHome>();
            listIndustrial = new List<VwIndustrialHome>();
            listCommercial = new List<VwCommercialHome>();
            listAgricultural = new List<VwAgriculturalHome>();
            listmembers = new List<TbTeam>();
            classifications = new List<TbEstateClassification>();
            Subclassifications = new List<TbSubClassification>();
            AllPurposese = new List<TbPurpose>();
        }

        public List<VwResidentialHome> listResidential { get; set; }
        public List<VwIndustrialHome> listIndustrial { get; set; }
        public List<VwCommercialHome> listCommercial { get; set; }
        public List<VwAgriculturalHome> listAgricultural { get; set; }
        public List<TbTeam> listmembers { get; set; }
        public List<TbEstateClassification> classifications { get; set; }
        public List<TbSubClassification> Subclassifications { get; set; }
        public List<TbPurpose> AllPurposese { get; set; }
        public TbAds Ads { get; set; }

        public int PurposeId { get; set; }
        [Required (ErrorMessage ="من فضلك اختر التصنيف")]
        public int ClassificationId { get; set; }
        [Required(ErrorMessage = "من فضلك اختر النوع")]
        public int SubClassificationId { get; set; }

    }
}

using Domains;


namespace RealEstate.Areas.Admin.Models
{
    public class AddIndustrialVwM
    {
        public AddIndustrialVwM()
        {
            listPurposes = new List<TbPurpose>();
            SubClassifications = new List<TbSubClassification>();
            IndustrialImages = new List<TbImage>();
        }

        public List<TbPurpose> listPurposes { get; set; }
        public List<TbSubClassification> SubClassifications { get; set; }

        public List<TbImage> IndustrialImages { get; set; }

        public string Image = "";

        public TbIndustrial industrial { get; set; }
    }
}

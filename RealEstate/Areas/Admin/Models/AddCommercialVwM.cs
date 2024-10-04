using Domains;


namespace RealEstate.Areas.Admin.Models
{
    public class AddCommercialVwM
    {
        public AddCommercialVwM()
        {
            listPurposes = new List<TbPurpose>();
            SubClassifications = new List<TbSubClassification>();
            CommercialImages = new List<TbImage>();
        }

        public List<TbPurpose> listPurposes { get; set; }
        public List<TbSubClassification> SubClassifications { get; set; }

        public List<TbImage> CommercialImages { get; set; }

        public string Image = "";

        public TbCommercial commercial { get; set; }
    }
}

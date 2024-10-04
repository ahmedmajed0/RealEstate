using Domains;

namespace RealEstate.Areas.Admin.Models
{
    public class AddAgriculturalVwM
    {
        public AddAgriculturalVwM()
        {
            listPurposes = new List<TbPurpose>();
            SubClassifications = new List<TbSubClassification>();
            AgriculturalImages = new List<TbImage>();
        }

        public List<TbPurpose> listPurposes { get; set; }
        public List<TbSubClassification> SubClassifications { get; set; }

        public List<TbImage> AgriculturalImages { get; set; }

        public string Image = "";

        public TbAgricultural agricultural { get; set; }
    }
}

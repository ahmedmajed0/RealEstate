using Domains;

namespace RealEstate.Areas.Admin.Models
{
    public class AddResidentialVwM
    {
        public AddResidentialVwM()
        {
            listPurposes = new List<TbPurpose>();
            SubClassifications = new List<TbSubClassification>();
            ResidentialImages = new List<TbImage>();
        }

        public List<TbPurpose> listPurposes { get; set; }
        public List<TbSubClassification> SubClassifications { get; set; }

        public List<TbImage> ResidentialImages { get; set; }

        public string Image ="";

        public TbResidential residential { get; set; }

    }
}

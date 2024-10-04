using Domains;

namespace RealEstate.Areas.Admin.Models
{
    public class ResidentialVwModel
    {
        public ResidentialVwModel()
        {
            listPurposes = new List<TbPurpose>();
            listSubClassification = new List<TbSubClassification>();
        }
        public List<TbPurpose> listPurposes { get; set; }
        public List<TbSubClassification> listSubClassification { get; set; }
        public TbResidential residentialEstate { get; set; }

    }
}

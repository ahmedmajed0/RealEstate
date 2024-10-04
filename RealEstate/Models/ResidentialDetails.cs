using Domains;

namespace RealEstate.Models
{
    public class ResidentialDetails
    {
        public ResidentialDetails()
        {
            images = new List<TbImage>();
        }
        public List<TbImage> images { get; set; }
        public TbResidential residential { get; set; }
    }
}

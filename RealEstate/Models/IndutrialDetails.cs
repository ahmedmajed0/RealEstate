using Domains;

namespace RealEstate.Models
{
    public class IndutrialDetails
    {
        public IndutrialDetails()
        {
            images = new List<TbImage>();
        }
        public List<TbImage> images { get; set; }
        public TbIndustrial industrial { get; set; }
    }
}

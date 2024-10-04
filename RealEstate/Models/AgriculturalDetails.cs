using Domains;

namespace RealEstate.Models
{
    public class AgriculturalDetails
    {
        public AgriculturalDetails()
        {
            images = new List<TbImage>();
        }
        public List<TbImage> images { get; set; }
        public TbAgricultural agricultural { get; set; }
    }
}

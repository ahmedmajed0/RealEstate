using Domains;


namespace RealEstate.Models
{
    public class CommercialDetails
    {
        public CommercialDetails()
        {
            images = new List<TbImage>();
        }
        public List<TbImage> images { get; set; }
        public TbCommercial commercial { get; set; }
    }
}

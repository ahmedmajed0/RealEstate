using Domains;

namespace RealEstate.Areas.Admin.Models
{
    public class AdsVwModel
    {
        public AdsVwModel()
        {
            AllAds = new List<TbAds>();
        }
        public TbAds Ad { get; set; }

        public List<TbAds> AllAds { get; set; }
    }
}

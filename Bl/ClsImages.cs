using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;

namespace Bl
{
    public interface IImagesService
    {
        /*سكني*/
        List<TbImage> ResidentialImages(int id);
        string ResidentialImage(int id);
        bool DeleteResidentialImages(int id);

        bool AddImages(List<TbImage> images);
        /*سكني*/


        /*تجاري*/
        List<TbImage> CommercialImages(int id);
        string CommercialImage(int id);
        bool DeleteCommercialImages(int id);

        /*تجاري*/


        /*زراعي*/
        List<TbImage> AgriculturalImages(int id);
        string AgriculturalImage(int id);
        bool DeleteAgriculturalImages(int id);

        /*زراعي*/


        /*صناعي*/
        List<TbImage> IndustrialImages(int id);
        string IndustrialImage(int id);
        bool DeleteIndustrialImages(int id);

        /*صناعي*/

    }
    public class ClsImages : IImagesService
    {
        readonly RealestateContext ctx;
        public ClsImages(RealestateContext context)
        {
            ctx = context;
        }

        /*سكني*/
        public List<TbImage> ResidentialImages(int id)
        {
            return ctx.TbImages.Where(a => a.ResidentialId == id).ToList();
        }

        public string ResidentialImage(int id)
        {
            return ctx.TbImages.Where(a => a.ResidentialId == id).Select(a => a.ImageName).FirstOrDefault();
        }

        public bool DeleteResidentialImages(int id)
        {
            try
            {
                List<TbImage> images = ResidentialImages(id);
                ctx.RemoveRange(images);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /*سكني*/


        /*تجاري*/
        public List<TbImage> CommercialImages(int id)
        {
            return ctx.TbImages.Where(a => a.CommercialId == id).ToList();
        }

        public string CommercialImage(int id)
        {
            return ctx.TbImages.Where(a => a.CommercialId == id).Select(a => a.ImageName).FirstOrDefault();
        }

        public bool DeleteCommercialImages(int id)
        {
            try
            {
                List<TbImage> images = CommercialImages(id);
                ctx.RemoveRange(images);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /*تجاري*/


        /*زراعي*/
        public List<TbImage> AgriculturalImages(int id)
        {
            return ctx.TbImages.Where(a => a.AgrculturalId == id).ToList();
        }

        public string AgriculturalImage(int id)
        {
            return ctx.TbImages.Where(a => a.AgrculturalId == id).Select(a => a.ImageName).FirstOrDefault();
        }

        public bool DeleteAgriculturalImages(int id)
        {
            try
            {
                List<TbImage> images = AgriculturalImages(id);
                ctx.RemoveRange(images);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /*زراعي*/


        
        /*زراعي*/
        public List<TbImage> IndustrialImages(int id)
        {
            return ctx.TbImages.Where(a => a.IndustrialId == id).ToList();
        }

        public string IndustrialImage(int id)
        {
            return ctx.TbImages.Where(a => a.IndustrialId == id).Select(a => a.ImageName).FirstOrDefault();
        }

        public bool DeleteIndustrialImages(int id)
        {
            try
            {
                List<TbImage> images = IndustrialImages(id);
                ctx.RemoveRange(images);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /*زراعي*/
        public bool AddImages(List<TbImage> images)
        {
            try
            {
                ctx.AddRange(images);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

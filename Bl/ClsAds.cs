using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;

namespace Bl
{
    public interface IAdsServices
    {
        bool Add(TbAds OAd);

        bool Edit(TbAds OAd);
        bool Delete(int id);
        List<TbAds> AllAds();
    }

    public class ClsAds : IAdsServices
    {
        readonly RealestateContext ctx;
        public ClsAds(RealestateContext context)
        {
            ctx = context;
        }

        public bool Add(TbAds OAd)
        {
            try
            {
                ctx.Add<TbAds>(OAd);
                ctx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public bool Edit(TbAds OAd)
        {
            try
            {
                var Oldadv = ctx.TbAds.Where(a => a.AdId == OAd.AdId).FirstOrDefault();
                Oldadv.ImageName = OAd.ImageName;
                ctx.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }

        }

        public TbAds GetById(int Id)
        {
            try
            {
                var OAd = ctx.TbAds.Where(a => a.AdId == Id).FirstOrDefault();
                if (OAd == null)
                    return new TbAds();

                return OAd;

            }
            catch
            {
                return new TbAds();
            }
        }

        public List<TbAds> AllAds()
        {
            return ctx.TbAds.ToList();
        }


        public bool Delete(int id)
        {
            try
            {
                var OAd = GetById(id);
                ctx.Remove<TbAds>(OAd);
                ctx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

    }
}

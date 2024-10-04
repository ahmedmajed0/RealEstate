using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;
using Microsoft.EntityFrameworkCore;

namespace Bl
{


    public interface IResidentialService
    {
        //string GetVideoString(int Id);
        bool Add(TbResidential OResidential);

        bool Edit(TbResidential OResidential);

        bool Delete(int id);
        TbResidential GetById(int Id);

        int LastAddedId();
        List<VwResidential> GetAll();

        List<VwResidentialHome> AllForHomePage();

        List<VwResidentialHome> AllForSearch(int purposeId , int subClaId);

        int ResidentialNo();

    }

    public class ClsResidential : IResidentialService
    {
        readonly RealestateContext ctx;
        public ClsResidential(RealestateContext context)
        {
            ctx = context;
        }

        //public string GetVideoString(int Id)
        //{
        //    try
        //    {
        //        return ctx.TbResidential.Where(a => a.ResidentialId == Id).Select(a => a.Video).FirstOrDefault();

        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}
        public bool Add(TbResidential OResidential)
        {
            try
            {
                ctx.Add<TbResidential>(OResidential);
                ctx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public bool Edit(TbResidential OResidential)
        {
            try
            {
                ctx.Entry(OResidential).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var OResidential = GetById(id);
                ctx.Remove<TbResidential>(OResidential);
                ctx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public TbResidential GetById(int Id)
        {
            try
            {
                var OResidentia = ctx.TbResidential.Where(a => a.ResidentialId == Id).FirstOrDefault();
                if (OResidentia == null)
                    return new TbResidential();

                return OResidentia;

            }
            catch
            {
                return new TbResidential();
            }
        }

        public int LastAddedId()
        {
            try
            {
                return ctx.TbResidential.OrderByDescending(a => a.ResidentialId).Select(a => a.ResidentialId).FirstOrDefault();
            }
            catch
            {
                return -1;
            }
        }

        public List<VwResidential> GetAll()
        {
            return ctx.VwResidential.ToList();
        }

        public List<VwResidentialHome> AllForHomePage()
        {
            return ctx.VwResidentialHome.GroupBy(a => a.Residential_Id).Select(a => a.First()).ToList();
        }

        public List<VwResidentialHome> AllForSearch(int purposeId, int subClaId)
        {
            return ctx.VwResidentialHome.Where(a => a.Purpose_Id == purposeId && a.SubCla_Id == subClaId).GroupBy(a => a.Residential_Id).Select(a => a.First()).ToList();
        }

        public int ResidentialNo()
        {
            return ctx.TbResidential.Count();
        }


    }
}

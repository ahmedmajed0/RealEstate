using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;
using Microsoft.EntityFrameworkCore;

namespace Bl
{


    public interface IIndustrialService
    {
        bool Add(TbIndustrial OIndustrial);
        bool Edit(TbIndustrial OIndustrial);

        bool Delete(int id);
        TbIndustrial GetById(int Id);

        int LastAddedId();
        List<VwIndustrial> GetAll();
        List<VwIndustrialHome> AllForHomePage();
        List<VwIndustrialHome> AllForSearch(int purposeId, int subClaId);
        int IndustrialNo();



    }

    public class ClsIndustrial : IIndustrialService
    {
        readonly RealestateContext ctx;
        public ClsIndustrial(RealestateContext context)
        {
            ctx = context;
        }

        public bool Add(TbIndustrial OIndustrial)
        {
            try
            {
                ctx.Add<TbIndustrial>(OIndustrial);
                ctx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public bool Edit(TbIndustrial OIndustrial)
        {
            try
            {
                ctx.Entry(OIndustrial).State = EntityState.Modified;
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
                var OIndustrial = GetById(id);
                ctx.Remove<TbIndustrial>(OIndustrial);
                ctx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public TbIndustrial GetById(int Id)
        {
            try
            {
                var OIndustrial = ctx.TbIndustrial.Where(a => a.IndustrialId == Id).FirstOrDefault();
                if (OIndustrial == null)
                    return new TbIndustrial();

                return OIndustrial;

            }
            catch
            {
                return new TbIndustrial();
            }
        }

        public int LastAddedId()
        {
            try
            {
                return ctx.TbIndustrial.OrderByDescending(a => a.IndustrialId).Select(a => a.IndustrialId).FirstOrDefault();
            }
            catch
            {
                return -1;
            }
        }

        public List<VwIndustrial> GetAll()
        {
            return ctx.VwIndustrial.ToList();
        }

        public List<VwIndustrialHome> AllForHomePage()
        {
            return ctx.VwIndustrialHome.GroupBy(a => a.Industrial_Id).Select(a => a.First()).ToList();
        }

        public List<VwIndustrialHome> AllForSearch(int purposeId, int subClaId)
        {
            return ctx.VwIndustrialHome.Where(a => a.Purpose_Id == purposeId && a.SubCla_Id == subClaId).GroupBy(a => a.Industrial_Id).Select(a => a.First()).ToList();
        }
        public int IndustrialNo()
        {
            return ctx.TbIndustrial.Count();
        }



    }
}

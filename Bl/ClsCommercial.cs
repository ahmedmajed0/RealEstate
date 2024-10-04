using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;
using Microsoft.EntityFrameworkCore;

namespace Bl
{


    public interface ICommercialService
    {
        bool Add(TbCommercial OCommercial);
        bool Edit(TbCommercial OCommercial);

        bool Delete(int id);
        TbCommercial GetById(int Id);

        int LastAddedId();
        List<VwCommercial> GetAll();
        List<VwCommercialHome> AllForHomePage();
        List<VwCommercialHome> AllForSearch(int purposeId, int subClaId);

        int CommercialNo();
    }

    public class ClsCommercial : ICommercialService
    {
        readonly RealestateContext ctx;
        public ClsCommercial(RealestateContext context)
        {
            ctx = context;
        }

        public bool Add(TbCommercial OCommercial)
        {
            try
            {
                ctx.Add<TbCommercial>(OCommercial);
                ctx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public bool Edit(TbCommercial OCommercial)
        {
            try
            {
                ctx.Entry(OCommercial).State = EntityState.Modified;
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
                var OCommercial = GetById(id);
                ctx.Remove<TbCommercial>(OCommercial);
                ctx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public TbCommercial GetById(int Id)
        {
            try
            {
                var OCommercial = ctx.TbCommercial.Where(a => a.CommercialId == Id).FirstOrDefault();
                if (OCommercial == null)
                    return new TbCommercial();

                return OCommercial;

            }
            catch
            {
                return new TbCommercial();
            }
        }

        public int LastAddedId()
        {
            try
            {
                return ctx.TbCommercial.OrderByDescending(a => a.CommercialId).Select(a => a.CommercialId).FirstOrDefault();
            }
            catch
            {
                return -1;
            }
        }

        public List<VwCommercial> GetAll()
        {
            return ctx.VwCommercial.ToList();
        }

        public List<VwCommercialHome> AllForHomePage()
        {
            return ctx.VwCommercialHome.GroupBy(a => a.Commercial_Id).Select(a => a.First()).ToList();
        }

        public List<VwCommercialHome> AllForSearch(int purposeId, int subClaId)
        {
            return ctx.VwCommercialHome.Where(a => a.Purpose_Id == purposeId && a.SubCla_Id == subClaId).GroupBy(a => a.Commercial_Id).Select(a => a.First()).ToList();
        }
        public int CommercialNo()
        {
            return ctx.TbCommercial.Count();
        }


    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;
using Microsoft.EntityFrameworkCore;

namespace Bl
{
    public interface IAgriculturalService
    {
        bool Add(TbAgricultural OAgricultural);
        bool Edit(TbAgricultural OAgricultural);

        bool Delete(int id);
        TbAgricultural GetById(int Id);

        int LastAddedId();
        List<VwAgricultural> GetAll();
        List<VwAgriculturalHome> AllForHomePage();

        List<VwAgriculturalHome> AllForSearch(int purposeId, int subClaId);

        int AgriculturalNo();

    }

    public class ClsAgricultural : IAgriculturalService
    {
        readonly RealestateContext ctx;
        public ClsAgricultural(RealestateContext context)
        {
            ctx = context;
        }

        public bool Add(TbAgricultural OAgricultural)
        {
            try
            {
                ctx.Add<TbAgricultural>(OAgricultural);
                ctx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public bool Edit(TbAgricultural OAgricultural)
        {
            try
            {
                ctx.Entry(OAgricultural).State = EntityState.Modified;
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
                var OAgricultural = GetById(id);
                ctx.Remove<TbAgricultural>(OAgricultural);
                ctx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public TbAgricultural GetById(int Id)
        {
            try
            {
                var OAgricultural = ctx.TbAgricultural.Where(a => a.AgrculturalId == Id).FirstOrDefault();
                if (OAgricultural == null)
                    return new TbAgricultural();

                return OAgricultural;

            }
            catch
            {
                return new TbAgricultural();
            }
        }

        public int LastAddedId()
        {
            try
            {
                return ctx.TbAgricultural.OrderByDescending(a => a.AgrculturalId).Select(a => a.AgrculturalId).FirstOrDefault();
            }
            catch
            {
                return -1;
            }
        }

        public List<VwAgricultural> GetAll()
        {
            return ctx.VwAgricultural.ToList();
        }

        public List<VwAgriculturalHome> AllForHomePage()
        {
            return ctx.VwAgriculturalHome.GroupBy(a => a.Agrcultural_Id).Select(a => a.First()).ToList();
        }

        public List<VwAgriculturalHome> AllForSearch(int purposeId, int subClaId)
        {
            return ctx.VwAgriculturalHome.Where(a => a.Purpose_Id == purposeId && a.SubCla_Id == subClaId).GroupBy(a => a.Agrcultural_Id).Select(a => a.First()).ToList();
        }

        public int AgriculturalNo()
        {
            return ctx.TbAgricultural.Count();
        }



    }
}


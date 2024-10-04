using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;

namespace Bl
{
    public interface IClassificationService
    {

        List<TbEstateClassification> AllClassification();
        List<TbSubClassification> AllSubClassification();
        List<TbSubClassification> ResidentialSubClassi();

        List<TbSubClassification> AgriculturalSubClassi();

        List<TbSubClassification> CommercialSubClassi();

        List<TbSubClassification> IndustrialSubClassi();
        List<TbPurpose> AllPurposes();

    }
    public class ClsClassification : IClassificationService
    {
        readonly RealestateContext ctx;
        public ClsClassification(RealestateContext context)
        {
            ctx = context;
        }

        public List<TbEstateClassification> AllClassification()
        {
            return ctx.TbEstateClassification.ToList();
        }

        public List<TbSubClassification> AllSubClassification()
        {
            return ctx.TbSubClassification.ToList();
        }

        public List<TbSubClassification> ResidentialSubClassi()
        {
            return ctx.TbSubClassification.Where(a => a.ClassificationId == 1).ToList();
        }


        public List<TbSubClassification> AgriculturalSubClassi()
        {
            return ctx.TbSubClassification.Where(a => a.ClassificationId == 3).ToList();
        }

        public List<TbSubClassification> CommercialSubClassi()
        {
            return ctx.TbSubClassification.Where(a => a.ClassificationId == 2).ToList();
        }

        public List<TbSubClassification> IndustrialSubClassi()
        {
            return ctx.TbSubClassification.Where(a => a.ClassificationId == 4).ToList();
        }

        public List<TbPurpose> AllPurposes()
        {
            return ctx.TbPurpose.ToList();
        }
    }
}

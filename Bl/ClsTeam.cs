using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;
using Microsoft.EntityFrameworkCore;

namespace Bl
{
    public interface ITeamService
    {
        bool Add(TbTeam member);
        bool Edit(TbTeam member);
        bool Delete(int id);
        TbTeam GetById(int Id);

        List<TbTeam> GetAll();

    }
    public class ClsTeam : ITeamService
    {
        readonly RealestateContext ctx;
        public ClsTeam(RealestateContext context)
        {
            ctx = context;
        }


        public bool Add(TbTeam member)
        {
            try
            {
                ctx.Add<TbTeam>(member);
                ctx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public bool Edit(TbTeam member)
        {
            try
            {
                var Omember = GetById(member.MemberId);

                Omember.Email = member.Email;
                Omember.Name = member.Name;
                Omember.Phone = member.Phone;
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
                var member = GetById(id);
                ctx.Remove<TbTeam>(member);
                ctx.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public TbTeam GetById(int Id)
        {
            try
            {
                var member = ctx.TbTeams.Where(a => a.MemberId == Id).FirstOrDefault();
                if (member == null)
                    return new TbTeam();

                return member;

            }
            catch
            {
                return new TbTeam();
            }
        }



        public List<TbTeam> GetAll()
        {
            return ctx.TbTeams.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AspitAktivitet.Models;

namespace AspitAktivitet.Healpers
{
    public class DB : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Planned> PlannedActivities { get; set; }

        public DbSet<Register> Registrations { get; set; }

        public List<Activity> GetOffers(DateTime nu)
        {
            int week = Util.getWeek(nu);

            List<Activity> Retur = new List<Activity>();

            var quary = from r in PlannedActivities
                        join a in Activities on r.ActivtyID equals a.ID
                        where nu.Year == r.Date.Year
                        && week == r.WeekNumber
                        select a;
            Retur = quary.ToList();
            return Retur;
        }

        public void Joined(int week)
        {
            var quary = from r in Registrations
                        join a in Activities on r.ActivityID equals a.ID
                        join u in Users on r.UserID equals u.ID
                        join p in PlannedActivities on r.ActivityID equals p.ActivtyID
                        where week == p.WeekNumber
                        select new
                        {
                            aname = a.Name,
                            uname = u.Name
                        };


        }

    }
}

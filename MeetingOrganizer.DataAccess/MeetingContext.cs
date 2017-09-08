using MeetingOrganizer.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.DataAccess
{
    public class MeetingContext : DbContext
    {
        public MeetingContext()
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<Meeting> Meeting { get; set; }
       
    }
}

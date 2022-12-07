using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.HotellDatabase
{
    public class Context : DbContext
    {
        private DbSet<Customer> Customers { get; set; }
        private DbSet<Room> Rooms { get; set; }
        private DbSet<Booking> Bookings { get; set; }

        protected void Onconfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=DESKTOP-R9FBETB;Initial Catalog=HotellApp;Integrated Security=True");

        }

    }
}

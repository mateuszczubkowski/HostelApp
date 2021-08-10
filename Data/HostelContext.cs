using HostelApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HostelApp.Data
{
    public class HostelContext : DbContext
    {
        public HostelContext() : base("HostelContext")
        {

        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
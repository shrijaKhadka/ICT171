using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ICT272.Models;

namespace ICT272.DAL
{
    public class HotelContext : DbContext
    {
        public HotelContext() : base("HotelContext")
        {

        }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<PartyEvent> PartyEvents  { get; set; }
        public DbSet<PartyType> partyTypes  { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}


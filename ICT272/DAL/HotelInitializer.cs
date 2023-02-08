using ICT272.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT272.DAL
{
    public class HotelInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HotelContext>
    {
        protected override void Seed(HotelContext context)
        {
            var attendees = new List<Attendee>
            {
            new Attendee{Name="Bhupen", AttendeeID=001, PartyEventID=1},
            new Attendee{Name="Shrija", AttendeeID=021, PartyEventID=2},
            new Attendee{Name="Naresh", AttendeeID=001, PartyEventID=2},

            };

            attendees.ForEach(s => context.Attendees.Add(s));
            context.SaveChanges();
            var courses = new List<PartyEvent>
            {
                new PartyEvent { PartyEventID = 12, PartyTypeID = 11, EventTime = DateTime.Parse("2023-01-07") },
                new PartyEvent { PartyEventID = 13, PartyTypeID = 12, EventTime = DateTime.Parse("2023-02-07") },
                new PartyEvent { PartyEventID = 14, PartyTypeID = 13, EventTime = DateTime.Parse("2023-03-07") }

            };
            PartyEvent.ForEach(s => context.PartyEvents.Add((PartyEvent)s));
            context.SaveChanges();
            var PartyType = new List<PartyType>
            {
                new PartyType {PartyTypeID = 11, Type="Birthday"},
                new PartyType {PartyTypeID = 12, Type="Weeding"},
                new PartyType {PartyTypeID = 13, Type="Business Seminar"}
            };
            PartyType.ForEach(s => context.partyTypes.Add(s));
            context.SaveChanges();
        }
    }
}
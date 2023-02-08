using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT272.Models
{
    public class PartyEvent
    {
        public int PartyEventID { get; set; }
        public int PartyTypeID { get; set; }
        public DateTime EventTime { get; set; }

        public PartyType PartyType { get; set; }
        public ICollection<Attendee> Attendees { get; set; }

        internal static void ForEach(Func<object, PartyEvent> p)
        {
            throw new NotImplementedException();
        }
    }
}
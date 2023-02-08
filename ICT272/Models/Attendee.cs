using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT272.Models
{
    public class Attendee
    {
        public int AttendeeID { get; set; }
        public string Name { get; set; }
        public int PartyEventID { get; set; }

        public PartyEvent PartyEvent { get; set; }
    }
}
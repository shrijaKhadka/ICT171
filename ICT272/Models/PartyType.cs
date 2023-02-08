using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT272.Models
{
    public class PartyType
    {
        public int PartyTypeID { get; set; }
        public string Type { get; set; }
        public ICollection<PartyEvent> PartyEvents { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QueueSystem1.DAL.DomainEntity
{
    public class ReportQueueDataItem
    {

        // item so sodrze podatoci od baza ke imame lista od 2 vakvi itemi, eden za salter A i eden za B.
        public int NumberOfServicedPersons { get; set; }
        public string ServicedBy { get; set; }

        public ReportQueueDataItem(DataRow row)
        {
            // TODO: Complete member initialization
            if (!string.IsNullOrWhiteSpace(row["NumberOfServicedPersons"].ToString()))
            {
                this.NumberOfServicedPersons = int.Parse(row["NumberOfServicedPersons"].ToString());
            }
            this.ServicedBy = row["ServicedBy"].ToString();
        }
    }
}
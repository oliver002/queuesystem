using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QueueSystem1.DAL.DomainEntity
{
    public class WaitingListItem
    {
        public string ServiceType { get; set; }
        public int ServiceNumber { get; set; }

        public WaitingListItem(DataRow row)
        {
            if (!string.IsNullOrWhiteSpace(row["ServiceType"].ToString()))
            {
                ServiceType = row["ServiceType"].ToString();
            }

            if (!string.IsNullOrWhiteSpace(row["ServiceNumber"].ToString()))
            {
                ServiceNumber = int.Parse(row["ServiceNumber"].ToString());
            }
        }
        
    }
}
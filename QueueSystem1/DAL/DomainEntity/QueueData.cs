using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QueueSystem1.DAL.DomainEntity
{
    public class QueueData
    {
        public int Id { get; set; }
        public DateTime WorkDay { get; set; }
        public int ServiceNumber { get; set; }
        public string ServiceType { get; set; }
        public DateTime StartWaitingTime { get; set; }
        public bool Serviced { get; set; }
        public bool Canceled { get; set; }
        public DateTime StartServicingTime { get; set; }
        public DateTime EndServicingTime { get; set; }
        public string ServicedBy { get; set; }

        public QueueData() { }

        public QueueData(DataRow dr)
        {
            Id = int.Parse(dr["Id"].ToString());
            WorkDay = DateTime.Parse(dr["WorkDay"].ToString());
            ServiceNumber = int.Parse(dr["ServiceNumber"].ToString());
            ServiceType = dr["ServiceType"].ToString();
            StartWaitingTime = DateTime.Parse(dr["StartWaitingTime"].ToString());
            Serviced = bool.Parse(dr["Serviced"].ToString());
            Canceled = bool.Parse(dr["Canceled"].ToString());
            if (!string.IsNullOrEmpty(dr["StartServicingTime"].ToString()))
            {
                StartServicingTime = DateTime.Parse(dr["StartServicingTime"].ToString());
            }

            if (!string.IsNullOrEmpty(dr["EndServicingTime"].ToString()))
            {
                EndServicingTime = DateTime.Parse(dr["EndServicingTime"].ToString());
            }

            if (!string.IsNullOrEmpty(dr["ServicedBy"].ToString()))
            {
                ServicedBy = dr["ServicedBy"].ToString();
            }
        }
    }
}
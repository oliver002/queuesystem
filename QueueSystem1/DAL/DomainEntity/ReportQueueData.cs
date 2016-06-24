using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QueueSystem1.DAL.DomainEntity
{
    public class ReportQueueData
    {
        // objekt sto se vraka od baza
        public List<ReportQueueDataItem> CounterData { get; set; }
        public List<ReportQueueDataItem> CounterDataDiff { get; set; }
        public List<ReportQueueDataItem> CounterDataCanceled { get; set; }

        public ReportQueueData(DataTable dt, DataTable dtDiffCounter, DataTable dtCanceled)
        {
            if (dt != null && dtDiffCounter != null && dtCanceled != null)
            {
                CounterData = new List<ReportQueueDataItem>();
                foreach (DataRow row in dt.Rows)
                {
                    CounterData.Add(new ReportQueueDataItem(row));
                }

                CounterDataDiff = new List<ReportQueueDataItem>();
                foreach (DataRow row in dtDiffCounter.Rows)
                {
                    CounterDataDiff.Add(new ReportQueueDataItem(row));
                }

                CounterDataCanceled = new List<ReportQueueDataItem>();
                foreach (DataRow row in dtCanceled.Rows)
                {
                    CounterDataCanceled.Add(new ReportQueueDataItem(row));
                }
            }
            else
            {
                throw new Exception("DataTable objektot e null");
            }
        }
    }
}
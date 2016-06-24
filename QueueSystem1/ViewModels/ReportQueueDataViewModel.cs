using QueueSystem1.DAL.DomainEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueSystem1.ViewModels
{
    public class ReportQueueDataViewModel
    {
        public DateTime ReportDate { get; set; }
        public int NumberOfServicedPersonsA { get; set; }
        public int NumberOfServicedPersonsB { get; set; }
        public int NumberOfServicedPersonsADiff { get; set; }
        public int NumberOfServicedPersonsBDiff { get; set; }
        public int NumberOfCanceledA { get; set; }
        public int NumberOfCanceledB { get; set; }

        public ReportQueueDataViewModel() { }

        public ReportQueueDataViewModel(ReportQueueData domainObject, DateTime reportDate)
        {
            ReportDate = reportDate;
            //NumberOfServicedPersons = domainObject.
            foreach (var reportQueueDataItem in domainObject.CounterData)
            {
                if (reportQueueDataItem.ServicedBy == "A")
                {
                    NumberOfServicedPersonsA = reportQueueDataItem.NumberOfServicedPersons;
                }
                else
                {
                    NumberOfServicedPersonsB = reportQueueDataItem.NumberOfServicedPersons;
                }
            }

            foreach (var reportQueueDataItem in domainObject.CounterDataDiff)
            {
                if (reportQueueDataItem.ServicedBy == "A")
                {
                    NumberOfServicedPersonsADiff = reportQueueDataItem.NumberOfServicedPersons;
                }
                else
                {
                    NumberOfServicedPersonsBDiff = reportQueueDataItem.NumberOfServicedPersons;
                }
            }

            foreach (var reportQueueDataItem in domainObject.CounterDataCanceled)
            {
                if (reportQueueDataItem.ServicedBy == "A")
                {
                    NumberOfCanceledA = reportQueueDataItem.NumberOfServicedPersons;
                }
                else
                {
                    NumberOfCanceledB = reportQueueDataItem.NumberOfServicedPersons;
                }
            }
        }
    }
}
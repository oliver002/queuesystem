using QueueSystem1.DAL;
using QueueSystem1.DAL.DomainEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QueueSystem1.BAL
{
    public class ReportService
    {
        public ReportQueueData GetReport(DateTime reportDate)
        { 
            //ode do baza
            DataTable dtReportData = new DataTable();
            DataTable dtReportDataDiffCounter = new DataTable();
            DataTable dtReportDataCanceled = new DataTable();
            //ReportQueueData returnValue = new ReportQueueData();
            using (SqlCommand comm = GenericDataAccess.CreateSqlCommand(true, "QueueData_GetReportByDate"))
            {
                comm.Parameters.AddWithValue("@WorkDay", reportDate);
                dtReportData = GenericDataAccess.ExecuteCommand(comm);
            }

            using (SqlCommand comm = GenericDataAccess.CreateSqlCommand(true, "QueueDataDiffCounter_GetReportByDate"))
            {
                comm.Parameters.AddWithValue("@WorkDay", reportDate);
                dtReportDataDiffCounter = GenericDataAccess.ExecuteCommand(comm);
            }

            using (SqlCommand comm = GenericDataAccess.CreateSqlCommand(true, "QueueDataCanceled_GetReportByDate"))
            {
                comm.Parameters.AddWithValue("@WorkDay", reportDate);
                dtReportDataCanceled = GenericDataAccess.ExecuteCommand(comm);
            }

            return new ReportQueueData(dtReportData, dtReportDataDiffCounter, dtReportDataCanceled);
        }
    }
}
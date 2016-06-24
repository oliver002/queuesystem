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
    public class QueueService
    {
        public QueueService() { }
        //serviceType treba da dojde on front-end.
        public void PutIntoQueue(string serviceType)
        {
           using (SqlCommand comm = GenericDataAccess.CreateSqlCommand(true, "QueueData_Insert"))
           {
                comm.Parameters.AddWithValue("@WorkDay", DateTime.Now.Date);
                comm.Parameters.AddWithValue("@ServiceType", serviceType);
                comm.Parameters.AddWithValue("@StartWaitingTime" , DateTime.Now);
                GenericDataAccess.ExecuteNonSelect(comm);
            }
        }

        public QueueData StartServing(string serviceType)
        {
            DataTable queueUpdated = new DataTable();
            QueueData returnValue = new QueueData();
            using (SqlCommand comm = GenericDataAccess.CreateSqlCommand(true, "QueueData_GetNextNumber"))
            {
                comm.Parameters.AddWithValue("@WorkDay", DateTime.Now.Date);
                comm.Parameters.AddWithValue("@ServiceType", serviceType);
                comm.Parameters.AddWithValue("@StartServicingTime", DateTime.Now);
                queueUpdated = GenericDataAccess.ExecuteCommand(comm);
            }
            // Ako uspesno updateiral vo baza
            if (queueUpdated.Rows.Count == 1)
            {
                returnValue = new QueueData(queueUpdated.Rows[0]);
            }
            return returnValue; 
        }

        public void CancelServing(string serviceType, int serviceNumber)
        {
            using(SqlCommand comm = GenericDataAccess.CreateSqlCommand(true, "QueueData_CancelServing"))
            {
                comm.Parameters.AddWithValue("@WorkDay", DateTime.Now.Date);
                comm.Parameters.AddWithValue("@ServiceType", serviceType);
                comm.Parameters.AddWithValue("@ServiceNumber", serviceNumber);
                GenericDataAccess.ExecuteNonSelect(comm);
            }
        }

        public void Served(string serviceType, int serviceNumber)
        {
            using (SqlCommand comm = GenericDataAccess.CreateSqlCommand(true, "QueueData_Served"))
            {
                comm.Parameters.AddWithValue("@WorkDay", DateTime.Now.Date);
                comm.Parameters.AddWithValue("@ServiceType", serviceType);
                comm.Parameters.AddWithValue("@ServiceNumber", serviceNumber);
                comm.Parameters.AddWithValue("@EndServicingTime", DateTime.Now);
                GenericDataAccess.ExecuteNonSelect(comm);
            }
        }

        public List<WaitingListItem> GetWaitingList()
        {
            List<WaitingListItem> waitingList = new List<WaitingListItem>();
            DataTable dt = new DataTable();
            using (SqlCommand comm = GenericDataAccess.CreateSqlCommand(true, "QueueData_GetWaitingList"))
            {
                comm.Parameters.AddWithValue("@WorkDay", DateTime.Now.Date);
                dt = GenericDataAccess.ExecuteCommand(comm);
            }
            foreach (DataRow row in dt.Rows)
            {
                waitingList.Add(new WaitingListItem(row));
            }
            
            return waitingList;
        }

    }
}
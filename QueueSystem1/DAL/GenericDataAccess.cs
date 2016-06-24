using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QueueSystem1.DAL
{
    public class GenericDataAccess
    {
        public static SqlCommand CreateSqlCommand(bool storedProcedure, string sql)
        {
            // ConnectionProvider provider = new ConnectionProvider();
            //SqlConnection conn = new SqlConnection();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=OLIVER-PC\SQLEXPRESS;Initial Catalog=QueueSystem;Integrated Security=True";
            // conn = provider.SqlConnection; //Baza.SqlSpoj();        

            SqlCommand comm = new SqlCommand();
            comm.CommandType = storedProcedure ? CommandType.StoredProcedure : CommandType.Text;
            comm.CommandText = sql;
            comm.Connection = connection;
            return comm;
        }
        public static DataTable ExecuteCommand(SqlCommand comm)
        {

            DataTable dt = new DataTable();
            try
            {
                if (comm.Connection.State != ConnectionState.Open) comm.Connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = comm;
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (comm.Connection.State != ConnectionState.Closed) comm.Connection.Close();
                comm.Connection.Dispose();
            }
            return dt;
        }
        public static int ExecuteNonSelect(SqlCommand comm)
        {
            int i = 0;
            try
            {
                if (comm.Connection.State != ConnectionState.Open) comm.Connection.Open();

                i = comm.ExecuteNonQuery(); // if stored procedure i is always -1
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (comm.Connection.State != ConnectionState.Closed) comm.Connection.Close();
                comm.Connection.Dispose();
            }
            return i;
        }
    }
    }

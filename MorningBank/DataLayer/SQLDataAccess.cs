using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MorningBank.DataLayer
{
    public class SQLDataAccess : IDataAccess
    {

        string CONNSTR = ConfigurationManager.ConnectionStrings["MYBANK"].ConnectionString;
        public SQLDataAccess() { }
        public SQLDataAccess(string connstr)  // to be able to change the connectionstring         
        {
            this.CONNSTR = connstr;
        }

        public DataTable GetManyRowsCols(string sql, List<DbParameter> PList, DbConnection conn = null, DbTransaction sqtr = null, bool bTransaction = false)
        {
            DataTable dt = new DataTable();
            if (bTransaction == false)
                conn = new SqlConnection(CONNSTR);

            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(sql, conn as SqlConnection);
                
                if (PList != null)
                {
                    foreach (DbParameter p in PList)
                        cmd.Parameters.Add(p);
                }
                if (bTransaction == true)
                    cmd.Transaction = sqtr as SqlTransaction;
                da.SelectCommand = cmd;
                da.Fill(dt);
            
            }catch (Exception)             
            {                 
                throw;             
            }
            finally
            {
                if (bTransaction == false)
                    conn.Close();
            }
            return dt;
        }
        public object GetSingleAnswer(string sql, List<DbParameter> PList, DbConnection conn = null, DbTransaction sqtr = null, bool bTransaction = false)
        {
            object obj = null;
            if (bTransaction == false)
                conn = new SqlConnection(CONNSTR);

            try {
                if (bTransaction == false)
                    conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn as SqlConnection);
                if (bTransaction == true) cmd.Transaction = sqtr as SqlTransaction;
                if (PList != null)
                {
                    foreach (DbParameter p in PList)
                        cmd.Parameters.Add(p);
                }
                obj = cmd.ExecuteScalar();
            }catch (Exception)
            {
                throw;
            }
            finally
            {
                if (bTransaction == false)
                    conn.Close();
            }
            return obj;
        }

        public int InsertUpdateDelete(string sql, List<DbParameter> PList, DbConnection conn = null, DbTransaction sqtr = null, bool bTransaction = false)
        {
            int rows = 0;
            if (bTransaction == false)
                conn = new SqlConnection(CONNSTR);
            try
            {
                if (bTransaction == false) conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn as SqlConnection);
                if (bTransaction == true)
                    cmd.Transaction = sqtr as SqlTransaction;
                if (PList != null)
                {
                    foreach (SqlParameter p in PList) cmd.Parameters.Add(p);
                }
                rows = cmd.ExecuteNonQuery();
                //rows = 1;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (bTransaction == false)
                    conn.Close();
            }
            return rows;
        }
    }
}
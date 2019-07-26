using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Mediateka
{
   public static class DAL
    {
        public static DataTable ExecSP(string spName, List<SqlParameter> sqlParameter = null)
        {
            String conectionString = Properties.Settings.Default.ConnetionString;
            SqlConnection sqlConnection = new SqlConnection();
            DataTable dataTable = new DataTable();

            try
            {
                //Connect to database
                sqlConnection = new SqlConnection(conectionString);
                sqlConnection.Open();

                //Build an sql command
                SqlCommand cmd = new SqlCommand(spName, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlParameter.ToArray());

                //Execute command
                SqlCommand command = sqlConnection.CreateCommand();
                SqlDataReader sqlDR = cmd.ExecuteReader();

                //Fill datatable with the result
                dataTable.Load(sqlDR);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //No matter what happens this will run
                sqlConnection.Close();
            }

            return dataTable;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DAL
{
    class Contact_CasesSqlDAL
    {
        private const string connectionString = @"Data Source= .\SQLEXPRESS;database = caseorganizer; User ID = te_student;Password = sqlserver1";
        private const string SQL_AssignContactToCase = "insert into contact_cases Values(@contactid, @caseid);";

        public bool AssignContactToCase(int contactId, int caseId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_AssignContactToCase, conn);
                    cmd.Parameters.AddWithValue("@contactid", contactId);
                    cmd.Parameters.AddWithValue("@caseid", caseId);
                    int changedRows = (int)cmd.ExecuteNonQuery();
                    return (changedRows > 0);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

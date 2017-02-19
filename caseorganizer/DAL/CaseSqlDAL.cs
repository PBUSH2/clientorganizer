using ConsoleApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DAL
{
    class CaseSqlDAL
    {
        private string SQL_ViewAllCases = "Select * from cases;";
        private string connectionString = @"Data Source= .\SQLEXPRESS;database = caseorganizer; User ID = te_student;Password = sqlserver1";
        private const string SQL_CreateNewCase = "Insert into cases (name, filed, openclosedpotential) Values(@name, @filed, @status); SELECT cast(scope_identity() AS INT);";
        private const string SQL_SearchCasesByCaseName = "Select * from cases where name = @name;";
        public List<Case> ViewAllCases()
        {
            List<Case> caseList = new List<Case>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_ViewAllCases, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Case c = new Case()
                        {
                            Name = Convert.ToString(reader["name"]),
                            CaseId = Convert.ToInt32(reader["case_id"]),
                            Filed = Convert.ToBoolean(reader["filed"]),
                            Number = Convert.ToInt32(reader["number"]),
                            Status = Convert.ToString(reader["openclosedpotential"])
                        };
                        caseList.Add(c);
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
            return caseList;
        }
        public bool CreateNewCase(Case c)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_CreateNewCase, conn);
                    cmd.Parameters.AddWithValue("@name", c.Name);
                    cmd.Parameters.AddWithValue("@filed", c.Filed);
                    cmd.Parameters.AddWithValue("@status", c.Status);
                    int changedRows = (int)cmd.ExecuteScalar();

                    return (changedRows > 0);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Case> SearchCasesByCaseName(string caseName)
        {
            List<Case> caseList = new List<Case>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_SearchCasesByCaseName, conn);
                    cmd.Parameters.AddWithValue("@name", caseName);

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while(reader.Read())
                    {
                        Case c = new Case()
                        {
                            Name = Convert.ToString(reader["name"]),
                            Status = Convert.ToString(reader["openclosedpotential"]),
                            Filed = Convert.ToBoolean(reader["filed"]),
                            CaseId = Convert.ToInt32(reader["case_id"]),
                            Number = Convert.ToInt32(reader["number"]),
                            
                        };
                        caseList.Add(c);                           
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return caseList;

        }
    }
}

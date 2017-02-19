using ConsoleApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DAL
{
    class ContactSqlDAL
    {
        private const string connectionString = @"Data Source= .\SQLEXPRESS;database = caseorganizer; User ID = te_student;Password = sqlserver1";

        private const string SQL_SearchContactsByLastName = "Select * from contact where contact.last_name = @lastname;";
        private const string SQL_ViewAllContacts = "Select * from contact";
        private const string SQL_CreateContact = "Insert into contact (first_name, last_name, phone, email, address, birth_date) values(@firstname, @lastname, @phone, @email, @address, @birthdate);Select cast(scope_identity() as int);";
        private const string SQL_UpdateEmail = "Update contact set email = @newemail where contact_id = @contactid; Select cast(scope_identity() as int);";

        public List<Contact> ViewAllContacts()
        {
            List<Contact> contactList = new List<Contact>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_ViewAllContacts, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Contact contact = new Contact()
                        {
                            ContactId = Convert.ToInt32(reader["contact_id"]),
                            FirstName = Convert.ToString(reader["first_name"]),
                            LastName = Convert.ToString(reader["last_name"]),
                            Address = Convert.ToString(reader["address"]),
                            BirthDate = Convert.ToDateTime(reader["birth_date"]),
                            //CaseId = Convert.ToInt32(reader["case_id"]),
                            Email = Convert.ToString(reader["email"]),
                            Phone = Convert.ToString(reader["phone"])
                        };
                        contactList.Add(contact);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return contactList;
        }

        public List<Contact> SearchContactsByLastName(string lastName)
        {
            List<Contact> contactList = new List<Contact>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL_SearchContactsByLastName, conn);
                cmd.Parameters.AddWithValue("@lastname", lastName);

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Contact c = new Contact()
                    {
                        ContactId = Convert.ToInt32(reader["contact_id"]),
                        FirstName = Convert.ToString(reader["first_name"]),
                        LastName = Convert.ToString(reader["last_name"]),
                       Address = Convert.ToString(reader["address"]),
                        BirthDate = Convert.ToDateTime(reader["birth_date"]),
                        //CaseId = Convert.ToInt32(reader["case_id"]),
                        Email = Convert.ToString(reader["email"]),
                        Phone = Convert.ToString(reader["phone"])
                    };
                    contactList.Add(c);
                
                }
              

            }
            catch (Exception)
            {

                throw;
            }
            return contactList;
        }
        public bool CreateNewContact(Contact c)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_CreateContact, conn);
                    cmd.Parameters.AddWithValue("@firstname", c.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", c.LastName);
                    cmd.Parameters.AddWithValue("@phone", c.Phone);
                    cmd.Parameters.AddWithValue("@email", c.Email);
                    cmd.Parameters.AddWithValue("@address", c.Address);
                    cmd.Parameters.AddWithValue("@birthdate", c.BirthDate);
                    int linesChanged = (int)cmd.ExecuteScalar();
                    return (linesChanged > 0);
                        
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public bool UpdateContactEmail(int contactId, string newEmail)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_UpdateEmail, conn);
                    cmd.Parameters.AddWithValue("@contactid", contactId);
                    cmd.Parameters.AddWithValue("@newemail", newEmail);
                    int changedRows = cmd.ExecuteNonQuery();
                    bool worked = (changedRows > 0);
                    return worked;
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
       

    }
}

//using ConsoleApplication1.DAL;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApplication1.CLI
//{
//    class UpdateContactCLI
//    {
//        public void UpdateContactInfo()
//        {


//            ContactSqlDAL dal = new ContactSqlDAL();

//            while (true)
//            {
//                Console.WriteLine("What information would you like to update?");
//                Console.WriteLine("1. Email")



//                switch (response.ToUpper())
//                {

//                    case response = "EMAIL":
//                        UpdateContactEmail();
//                        break;

//                    default:
//                        break;
//                }
//            }

//        }
//        public void UpdateContactEmail()
//        {
//            SearchContactsByLastName();

//            int clientId = CLIHelper.GetInteger("Please enter client ID");

//            string newEmail = CLIHelper.GetString("Please enter new email: ");
//            ContactSqlDAL dal = new ContactSqlDAL();
//            bool worked = dal.UpdateContactEmail(clientId, newEmail);
//            if (worked)
//            {
//                Console.WriteLine("***Email successfully updated!!***");
//            }
//            else
//            {
//                Console.WriteLine("***EMAIL NOT UPDATED***");
//            }
//        }
//    }
//}

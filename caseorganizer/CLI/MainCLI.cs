using ConsoleApplication1.DAL;
using ConsoleApplication1.Models;
using ProjectDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.CLI
{
    class MainCLI
    {
        const string Command_ViewAllContacts = "1";
        const string Command_ViewAllCases = "2";
        const string Command_SearchContactsByLastName = "3";
        const string Command_SearchCasesByCaseName = "4";
        const string Command_CreateNewContact = "5";
        const string Command_CreateNewCase = "6";
        const string Command_AssignContactToCase = "7";
        const string Command_UpdateClientInfo = "8";


        public void RunCLI()
        {
            Console.WriteLine("Welcome to the Case Organizer");

            MainMenu();



            while (true)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case Command_ViewAllContacts:
                        ViewAllContacts();
                        break;
                    case Command_ViewAllCases:
                        ViewAllCases();
                        break;
                    case Command_SearchContactsByLastName:
                        SearchContactsByLastName();
                        break;
                    case Command_SearchCasesByCaseName:
                        SearchCasesByCaseName();
                        break;
                    case Command_CreateNewContact:
                        CreateNewContact();
                        break;
                    case Command_CreateNewCase:
                        CreateNewCase();
                        break;
                    case Command_AssignContactToCase:
                        AssignContactToCase();
                        break;
                    case Command_UpdateClientInfo:
                        UpdateContactInfo();
                        break;

                    default:
                        break;
                }
            }



        }

        public void MainMenu()
        {
            Console.WriteLine("Make Selection:");
            Console.WriteLine();
            Console.WriteLine("1. View All Contacts");
            Console.WriteLine("2. View All Cases");
            Console.WriteLine("3. Search Contacts by Last Name");
            Console.WriteLine("4. Search Cases by Case Name");
            Console.WriteLine("5. Create New Contact");
            Console.WriteLine("6. Create New Case");
            Console.WriteLine("7. Assign Contact to Case");
            Console.WriteLine("8. Update Client Information");
            Console.WriteLine("q. Quit");

        }

        public void ViewAllContacts()
        {
            ContactSqlDAL dal = new ContactSqlDAL();
            List<Contact> contactList = dal.ViewAllContacts();

            contactList.ForEach(contact =>
            Console.WriteLine(contact)
            );
        }
        public void ViewAllCases()
        {
            List<Case> caseList = new List<Case>();
            CaseSqlDAL dal = new CaseSqlDAL();
            caseList = dal.ViewAllCases();

            caseList.ForEach(c =>
                Console.WriteLine(c));
        }
        public void SearchContactsByLastName()
        {
            List<Contact> contactList = new List<Contact>();
            ContactSqlDAL dal = new ContactSqlDAL();
            Console.Write("Please enter last name: ");
            string lastName = Console.ReadLine();


            contactList = dal.SearchContactsByLastName(lastName);

            contactList.ForEach(c =>
            Console.WriteLine(c));

        }
        public void SearchCasesByCaseName()
        {
            List<Case> caseList = new List<Case>();
            CaseSqlDAL dal = new CaseSqlDAL();
            string caseName = CLIHelper.GetString("Please Enter Case Name");
            caseList = dal.SearchCasesByCaseName(caseName);

            caseList.ForEach(c =>
            Console.WriteLine(c));


        }
        public void CreateNewContact()

        {
            ContactSqlDAL dal = new ContactSqlDAL();
            Contact c = new Contact();
            Console.Write("Please Enter First Name: ");
            c.FirstName = Console.ReadLine();

            Console.Write("Please Enter Last Name: ");
            c.LastName = Console.ReadLine();

            Console.Write("Please Enter Phone Number:");
            c.Phone = Console.ReadLine();

            Console.Write("Please Enter Email:");
            c.Email = Console.ReadLine();

            Console.Write("Please Enter Address: ");
            c.Address = Console.ReadLine();

            Console.Write("Please Enter Birth Date: ");
            c.BirthDate = Convert.ToDateTime(Console.ReadLine());



            bool worked = dal.CreateNewContact(c);
            if (worked)
            {
                Console.WriteLine("Contact successfully created!");
            }
            else
            {
                Console.WriteLine("Contact not created.");

            }


        }
        public void CreateNewCase()
        {
            CaseSqlDAL dal = new CaseSqlDAL();

            Case c = new Case();


            Console.Write("Enter Case Name: ");
            c.Name = Console.ReadLine();

            Console.Write("Enter Status (open/closed/potential): ");
            c.Status = Console.ReadLine();
            while (true)
            {
                Console.Write("Filed? y/n");
                string response = Console.ReadLine();
                if (response.ToUpper() == "Y")
                {
                    c.Filed = true;
                    break;
                }
                else if (response.ToUpper() == "N")
                {
                    c.Filed = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                }
            }
            bool worked = dal.CreateNewCase(c);
            if (worked)
            {
                Console.WriteLine("Case successfully created!");

            }
            else
            {
                Console.WriteLine("Case NOT created.");
            }
        }
        public void AssignContactToCase()
        {
            Contact_CasesSqlDAL dal = new Contact_CasesSqlDAL();
            SearchContactsByLastName();

            int contactId = CLIHelper.GetInteger("Enter Contact ID: ");

            SearchCasesByCaseName();
            int caseId = CLIHelper.GetInteger("Enter Case ID");

            bool worked = dal.AssignContactToCase(contactId, caseId);

            if (worked)
            {
                Console.WriteLine("Contact Added To Case!");
            }
            else
            {
                Console.WriteLine("Contact NOT added to case.");
            }



        }
        public void UpdateContactInfo()
        {
            const string Command_Email = "1";
            const string Command_Address = "2";
            const string Command_Phone = "3";

            
            Console.WriteLine("What information would you like to update?");
            Console.WriteLine("1. Email");
            Console.WriteLine("2. Address");
            Console.WriteLine("3. Phone");
          
                string response = CLIHelper.GetString("Make selection");

                switch (response.ToUpper())
                {

                    case Command_Email:
                        UpdateContactEmail();
                        break;

                    default:
                        break;
                }
            

        }
        public void UpdateContactEmail()
        {
            SearchContactsByLastName();

            int clientId = CLIHelper.GetInteger("Please enter client ID");

            string newEmail = CLIHelper.GetString("Please enter new email: ");
            ContactSqlDAL dal = new ContactSqlDAL();
            bool worked = dal.UpdateContactEmail(clientId, newEmail);
            if (worked)
            {
                Console.WriteLine("***Email successfully updated!!***");
            }
            else
            {
                Console.WriteLine("***EMAIL NOT UPDATED***");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Models
{
    class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int CaseId { get; set; }

        public override string ToString()
        {
            return ContactId.ToString().PadRight(10) + FirstName.PadRight(15) + LastName.PadRight(15) + Email;
        }
    }
}

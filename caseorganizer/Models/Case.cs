using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Models
{
    class Case
    {
        public int CaseId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public bool Filed { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return CaseId.ToString().PadRight(5) + Name.PadRight(15) + Number.ToString().PadRight(8) + Filed.ToString().PadRight(10) + Status;
        }
    }
}

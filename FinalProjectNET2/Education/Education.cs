using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectNET2
{
    public class Education
    {
        public int EducationId { get; set; }
        public string InstitutionName { get; set; }
        public string Level { get; set; } // Home, Work, Mobile, etc.
        public string Address { get; set; } // Home, Work, Mobile, etc.

        public override string ToString()
        {
            string formattted = string.Format("{0}\t {1}\t {2}\t| {3}\t ", EducationId, InstitutionName, Level, Address);
            return formattted;
        }
    }
}

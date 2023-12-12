using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectNET2
{
    public class PhoneNumber
    {
        public int PhoneNumberId { get; set; }
        public string Number { get; set; }
        public string Type { get; set; } // Home, Work, Mobile, etc.
        public int ResumeId { get; set; } // Foreign key referencing the main resume table



        public override string ToString()
        {
            string formattted = string.Format("{0}\t {1}\t {2}\t| {3}\t ", PhoneNumberId, Number, Type, ResumeId);
            return formattted;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectNET2
{
    public class References
    {
        public int ReferenceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }




        public override string ToString()
        {
            string formattted = string.Format("{0}\t {1}\t {2}\t {3}", ReferenceId, Name, Description,PhoneNumber);
            return formattted;
        }
    }
}

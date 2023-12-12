using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectNET2
{
    public class Hobbies
    {
        public int HobbiesId { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } // Sport, Read, Walk, etc.
        



        public override string ToString()
        {
            string formattted = string.Format("{0}\t {1}\t {2}", HobbiesId, Description, Type);
            return formattted;
        }
    }
}

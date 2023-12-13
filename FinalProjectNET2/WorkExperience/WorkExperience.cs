using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectNET2
{
    public class WorkExperience
    {
        public int WorkExperienceId { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string YearsSpent { get; set; }


        public override string ToString()
        {
            string formattted = string.Format("{0}\t {1}\t {2}\t {3}", WorkExperienceId, CompanyName, JobTitle, YearsSpent);
            return formattted;
        }
    }
}

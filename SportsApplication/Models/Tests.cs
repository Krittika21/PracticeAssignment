using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApplication.Models
{
    public class Tests
    {
        public int TestsID { get; set; }

        public string TestType { get; set; }
        //public int ID { get; set; }
        public DateTime TestDate { get; set; }
        public int ParticipantCount { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }

    public class TestType
    {
        
    }
}

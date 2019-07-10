using System.ComponentModel.DataAnnotations.Schema;

namespace SportsApplication.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        
        public int TestsID { get; set; }

       
        public int AthletesID { get; set; }

        
        public int SAthletesID { get; set; }

        [ForeignKey("TestsID")]
        public virtual Tests Tests { get; set; }
        [ForeignKey("AthletesID")]
        public virtual Athletes Athletes { get; set; }
        [ForeignKey("SAthletesID")]
        public virtual SAthletes SAthletes { get; set; }
    }
}
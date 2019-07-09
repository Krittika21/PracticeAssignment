using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsApplication.Models
{
    public class Athletes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AthletesID { get; set; }
        //public string TestType { get; set; }
        public string ParticipantName { get; set; }
        public double Distance { get; set; }
        public string Fitness { get; set; }

        public virtual ICollection<Enrollment> Enrollements { get; set; }
    }
}
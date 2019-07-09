using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsApplication.Models
{
    public class SAthletes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SAthletesID { get; set; }
        //public string TestType { get; set; }
        public string Ranking { get; set; }
        public double Seconds { get; set; }
        public string FitnessRating { get; set; }

        public virtual ICollection<Enrollment> Enrollements { get; set; }
    }
}
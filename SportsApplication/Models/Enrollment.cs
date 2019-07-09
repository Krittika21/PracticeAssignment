namespace SportsApplication.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int TestsID { get; set; }
        public int AthletesID { get; set; }
        public int SAthleteID { get; set; }

        public virtual Tests Tests { get; set; }
        public virtual Athletes Athletes { get; set; }
        public virtual SAthletes SAthletes { get; set; }
    }
}
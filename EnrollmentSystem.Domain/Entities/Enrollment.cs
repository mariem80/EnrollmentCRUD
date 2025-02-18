namespace EnrollmentSystem.Domain.Entities;

public class Enrollment
{
    public int StudentID { get; set; }
    public int CourseID { get; set; }
    public DateTime? EnrollmentDate { get; set; }
    public string Grade { get; set; }
    public required Student Student { get; set; }
    public required Course Course { get; set; } 

}

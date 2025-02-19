namespace EnrollmentSystem.Domain.Entities;

public class Enrollment
{
    public int StudentID { get; set; }
    public int CourseID { get; set; }
    public DateTime? EnrollmentDate { get; set; }
    public string Grade { get; set; }
    public Student Student { get; set; }
    public Course Course { get; set; } 

}

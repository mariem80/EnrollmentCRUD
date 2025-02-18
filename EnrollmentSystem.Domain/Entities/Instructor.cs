namespace EnrollmentSystem.Domain.Entities;

public class Instructor
{
    public int InstructorID { get; set; }
    public required string InstructorName { get; set; }
    public required string Email { get; set; }
    public ICollection<Course> Courses { get; set; }
}

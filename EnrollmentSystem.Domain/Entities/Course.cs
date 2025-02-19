namespace EnrollmentSystem.Domain.Entities;

public class Course
{
    public int CourseID { get; set; }
    public string CourseName { get; set; }
    public int InstructorID { get; set; }
    public Instructor Instructor { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }

}

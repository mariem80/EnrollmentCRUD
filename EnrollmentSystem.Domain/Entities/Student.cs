namespace EnrollmentSystem.Domain.Entities;

public class Student
{
    public int StudentID { get; set; }
    public required string StudentName { get; set; }
    public required string StudentEmail { get; set; }
    public required string StudentPassword { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }

}

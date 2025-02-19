using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.DTOs.Enrollment.Responses;

public class EnrollmentDto
{
    public string StudentName { get; set; }
    public string CourseName { get; set; }
    public string InstructorName { get; set; }
    public string? Grade { get; set; }
}

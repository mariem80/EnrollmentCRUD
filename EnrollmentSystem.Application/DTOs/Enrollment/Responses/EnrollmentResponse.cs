using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.DTOs.Enrollment.Responses;

public class EnrollmentResponse
{
    public int StudentId { get; set; }
    public string Status { get; set; }

    public EnrollmentResponse(int studentId, string status)
    {
        StudentId = studentId;
        Status = status;
    }
}

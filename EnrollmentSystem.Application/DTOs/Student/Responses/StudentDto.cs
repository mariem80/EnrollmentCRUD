using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EnrollmentSystem.Application.DTOs.Student.Responses;

public class StudentDto
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public string StudentEmail { get; set; }
    [JsonIgnore]
    public string StudentPassword { get; set; }
}

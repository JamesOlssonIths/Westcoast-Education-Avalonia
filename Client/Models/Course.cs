using System;
using System.Collections.Generic;

namespace Westcoast_Education_Avalonia.Models;

public class Course
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string CourseNumber { get; set; }
    public required string Title { get; set; }
    public int Duration { get; set; }
    public string DurationUnit { get; set; } = "veckor";
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsOnline { get; set; }
    public string? TeacherName { get; set; }

}
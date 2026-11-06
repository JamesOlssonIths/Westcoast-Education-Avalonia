using System;
using System.Collections.Generic;

namespace Westcoast_Education_Avalonia.Models;

public class Course
{
    public string CourseNumber { get; set; }
    public string? Title { get; set; }
    public string? TotalWeeks { get; set; }
    public bool Remote { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime StartDate { get; set; }

    public List<Student> Students { get; set; } =[];
     public Teacher? Teacher { get; set; }
    public Course(string courseNumber, string title, bool remote)
    {
        CourseNumber = courseNumber;
        Title = title;
        Remote = remote;
    }
}
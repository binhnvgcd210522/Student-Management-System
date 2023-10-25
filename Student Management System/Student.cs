using System;
using System.Collections.Generic;
using System.Linq;

class Student : Person
{    
    public List<Course> Courses { get; set; } = new List<Course>();

    public Student(int studentID, string name, string contactInfo) : base(studentID, name, contactInfo)
    {
        
    }
    static int studentID = 0;

    public void EnrollInCourse(Course course)
    {
        if (Courses.Contains(course))
        {
            Console.WriteLine("This student already in this course.");
        }
        else
        {
            Courses.Add(course);
            course.AddStudent(this);
            Console.WriteLine($"{Name} has been enrolled in {course.CourseName}.");
        }        
    }

    public void ViewCourses()
    {
        Console.WriteLine($"Student {Name} is enrolled in the following Courses:");
        foreach (var course in Courses)
        {
            Console.WriteLine($"- {course.CourseName}");
        }
        Console.WriteLine();
    }

    public static Student CreateStudent()
    {
        studentID++;
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();
        Console.Write("Enter student contact info: ");
        string contactInfo = Console.ReadLine();               
        return new Student(studentID, name, contactInfo);
    }
    
    public Student Edit()
    {
        Console.WriteLine("Edit information:");
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("ContactInfo");
        string contactInfo = Console.ReadLine();
        return new Student(id, name, contactInfo);
    }

    public override void DisplayInfor()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"ID: {Id}, Name: {Name}, Contact Info: {ContactInfo}");
        if (Courses.Any())
        {
            ViewCourses();            
        }        
        Console.ResetColor();
    }
}

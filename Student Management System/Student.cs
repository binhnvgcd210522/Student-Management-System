using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

class Student : Person
{    
    public List<Course> Courses { get; set; } = new List<Course>(); // ê hắn tạo ra list mới tức là mỗi khi edit hắn sẽ tạo ra 1 list mới, list cũ k liê nquan nữa, lỗi ở đây, bỏ đoạn sau new ok k

    public Student(int studentID, string name, string contactInfo) : base(studentID, name, contactInfo)
    {
        // h làm sao 
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
        Console.WriteLine($"Student {Name} is enrolled in the following courses:");
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
    
    public void Edit()
    {
        Console.WriteLine("Edit information:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("ContactInfor: ");
        string contactInfo = Console.ReadLine();        
        this.Name = name; 
        this.ContactInfor = contactInfo;     
        
    }

    public override void DisplayInfor()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"ID: {Id}, Name: {Name}, Contact Info: {ContactInfor}");
        if (Courses.Any())
        {
            ViewCourses();            
        }        
        Console.ResetColor();
    }    
}

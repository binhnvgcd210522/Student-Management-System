using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

class Course
{
    public int CourseID { get; set; }
    public string CourseName { get; set; }
    public Instructor Instructor { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();

    static int courseID = 0;
    public Course(int courseID, string courseName, Instructor instructor)
    {
        CourseID = courseID;
        CourseName = courseName;
        Instructor = instructor;
    }

    public void AddStudent(Student student)
    {        
        Students.Add(student);
    }

    public void Remove(Student student, List<Student> students)
    {
        Students.Remove(student);
    }

    public void Remove(Instructor instructor)
    {
        Instructor = null;        
    }
    
    public static Course CreateCourse( string courseName, Instructor instructor)
    {
        courseID++;                       
        return new Course(courseID, courseName, instructor);
    }

    public void Edit(int id, string name, Instructor instructor)
    {
        this.CourseID = id;
        this.CourseName = name;
        this.Instructor = instructor;
    }
    public void Edit(int id, string name)
    {
        this.CourseID = id;
        this.CourseName = name;        
    }

    public void DisplayInfo()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Course ID: {CourseID}");
        Console.WriteLine($"Course Name: {CourseName}");
        if (Instructor != null)
        {
            Console.WriteLine($"Instructor: {Instructor.Name}");
        }
        else
            Console.WriteLine("Not assigned teacher yet");
        if (Students.Any())
        {
            Console.WriteLine("Students:");
            foreach (var student in Students)
            {
                Console.WriteLine($"- Name: {student.Name}");
            }
        }        
        Console.ResetColor();
    }
}

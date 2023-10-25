using System;
using System.Collections.Generic;
using System.Xml.Linq;

class Course
{
    public int CourseID { get; set; }
    public string CourseName { get; set; }
    public Instructor Instructor { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();

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
    static int courseID = 0;
    
    public static Course CreateCourse( string courseName, Instructor instructor)
    {
        courseID++;               
        return new Course(courseID, courseName, instructor);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Course ID: {CourseID}");
        Console.WriteLine($"Course Name: {CourseName}");
        if (Instructor != null)
        {
            Console.WriteLine($"Instructor: {Instructor}");
        }
        else
            Console.WriteLine("Not assigned teacher yet");
        Console.WriteLine("Students:");
        foreach (var student in Students)
        {
            Console.WriteLine($"- ID: {student.Id} name: {student.Name}");
        }
    }

    
}

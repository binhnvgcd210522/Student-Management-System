using System;
using System.Collections.Generic;
using System.Linq;

class Instructor : Person
{    
    public List<Course> coursesTaught { get; set; } = new List<Course>();

    public Instructor(int instructorID, string name, string contactInfo) : base(instructorID, name, contactInfo)
    {
        
    }
    static int instructorID = 0;
    public static Instructor CreateInstructor()
    {
        instructorID++;
        Console.Write("Enter instructor name: ");
        string name = Console.ReadLine();
        Console.Write("Enter instructor contact info: ");
        string contactInfo = Console.ReadLine();        
        return new Instructor(instructorID, name, contactInfo);
    }
    public Instructor Edit()
    {
        Console.WriteLine("--Edit instructor information--");
        Console.Write("New ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("New Name: ");
        string name = Console.ReadLine();
        Console.Write("New ContactInfor");
        string contactInfo = Console.ReadLine();
        return new Instructor(id, name, contactInfo);
    }

    public void InsertCourseTaught(Course course)
    {   
        int index = coursesTaught.IndexOf(course);
        if (index == -1)
        {
            coursesTaught.Add(course);
        }
        else
        {
            coursesTaught[index] = course;
        }
    }

    public void Remove(Course course)
    {
        coursesTaught.Remove(course);
    }

    public override void DisplayInfor()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"ID: {Id}, Name: {Name}, Contact Info: {ContactInfor}");
        if (coursesTaught.Any() )
        {
            Console.WriteLine("The Instructor is teaching these course: ");
            foreach (Course course in coursesTaught)
            {
                Console.WriteLine($"-{course.CourseName}");                
            }
        }                
        Console.ResetColor();
    }
}

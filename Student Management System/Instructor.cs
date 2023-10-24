using System;
using System.Collections.Generic;

class Instructor : Person
{    
    public List<Course> CoursesTaught { get; set; } = new List<Course>();

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
}

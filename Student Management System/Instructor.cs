using Student_Management_System;
using System;
using System.Collections.Generic;

class Instructor : Person, EditPerson
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
        Console.WriteLine("New Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("New ContactInfo");
        string contactInfo = Console.ReadLine();
        return new Instructor(id, name, contactInfo);
    }

    public void insertCourseTaught(Course course)
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
}

using System;
using System.Runtime.InteropServices;

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ContactInfo { get; set; }

    public Person(int id, string name, string contactInfo)
    {
        Id = id;
        Name = name;
        ContactInfo = contactInfo;
    }

    public virtual void DisplayInfo()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"ID: {Id}, Name: {Name}, Contact Info: {ContactInfo}");
        Console.ResetColor();
    }    
}

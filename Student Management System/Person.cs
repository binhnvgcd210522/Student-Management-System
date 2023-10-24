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

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}\nName: {Name}\nContact Info: {ContactInfo}");
    }

    public Person Edit()
    {
        Console.WriteLine("Edit information:");
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("ContactInfo");
        string contactInfo = Console.ReadLine();
        return new Person(id, name, contactInfo);
    }
}

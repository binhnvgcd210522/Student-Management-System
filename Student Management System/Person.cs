abstract class Person
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

    public abstract void DisplayInfor();
}

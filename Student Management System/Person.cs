abstract class Person
{
    private int _id;
    private string _name;
    private string _contacInfor;
    public int Id {
        get { return this._id; }   
        set { this._id = value; } 
    }
    public string Name {
         get { return this._name; }
         set {this._name = value; }
    }
    public string ContactInfor {
        get { return this._contacInfor; } 
        set { this._contacInfor = value; } 
    }

    public Person(int id, string name, string contactInfo)
    {
        this._id = id;
        this._name = name;
        this._contacInfor = contactInfo;
    }

    public abstract void DisplayInfor();
}

using System;

public class Citizens : IIdentifiable
{
    private string name;
    private int age;
    private string id;

    public Citizens(string id, string name, int age)
    {
        this.Id = id;
        this.Name = name;
        this.Age = age;
    }

    public string Id { get { return this.id; } private set { this.id = value; } }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }
}
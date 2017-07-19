using System;

public class Pet : IBirthdatable
{
    private string name;
    private string birthdate;

    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Birthdate { get { return this.birthdate; } private set { this.birthdate = value; }}
}
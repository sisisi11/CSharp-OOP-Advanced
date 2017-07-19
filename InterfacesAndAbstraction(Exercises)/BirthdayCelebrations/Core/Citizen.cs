using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Citizen : IIdentifiable, IBirthdatable
{
    private string name;
    private int age;

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public string Name { get { return this.name; } set { this.name = value; } }
    public int Age { get { return this.age; } set { this.age = value; } }

    public string Id { get; }
    public string Birthdate { get; }
}


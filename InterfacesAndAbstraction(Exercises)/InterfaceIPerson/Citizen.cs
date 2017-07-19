using System;

public class Citizen : IPerson, IBirthable, IIdentifiable
{
    public Citizen(string name, int age, string birthDate, string id)
    {
        Name = name;
        Age = age;
        BirthDate = birthDate;
        Id = id;
    }

    public string Name { get; }

    public int Age { get; }

    public string BirthDate { get; }

    public string Id { get; }
}
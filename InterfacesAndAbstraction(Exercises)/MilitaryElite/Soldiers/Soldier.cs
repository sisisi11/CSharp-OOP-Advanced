using System;

public abstract class Soldier : ISoldier
{
    public Soldier(string id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}
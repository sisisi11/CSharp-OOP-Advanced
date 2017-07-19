using System;
public class Citizen : IBuyer
{
    public Citizen(string birthday, string name, int age, string id)
    {
        this.Birthday = birthday;
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Food = 0;
    }

    public string Birthday { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Id { get; set; }
    public int Food { get; private set; }
    public void BuyFood()
    {
        this.Food += 10;
    }
}
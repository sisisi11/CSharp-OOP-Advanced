using System;

public class Robots : IIdentifiable
{
    private string model;
    private string id;

    public Robots(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }
    
    public string Id { get { return this.id; } private set { this.id = value; }}

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

}
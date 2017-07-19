using System;

public class Robot : IIdentifiable
{
    public string id;
    private string model;

    public Robot(string id, string model)
    {
        this.Id = id;
        this.Model = model;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public string Id { get { return this.id; } private set { this.id = value; } }
}
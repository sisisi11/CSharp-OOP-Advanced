using System;
using System.Text;

public class Spy : Soldier, ISpy
{
    private string codeNumber;
    public Spy(string id, string firstName, string lastName, string codeNumber) : base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public string CodeNumber { get { return this.codeNumber; } private set { this.codeNumber = value; } }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id}")
            .Append(Environment.NewLine).Append($"Code Number: {this.CodeNumber.TrimStart('0')}")
            .Append(Environment.NewLine);

        return sb.ToString();
    }
}
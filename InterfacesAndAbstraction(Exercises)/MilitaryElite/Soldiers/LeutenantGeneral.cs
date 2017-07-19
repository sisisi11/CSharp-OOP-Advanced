using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    private IList<Private> privates;

    public LeutenantGeneral(string id, string firstName, string lastName, double salary, IList<Private> privates) : base(id, firstName, lastName, salary)
    {
        this.Privates = privates;
    }

    public IList<Private> Privates { get { return this.privates; } private set { this.privates = value; } }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}")
            .Append(Environment.NewLine).Append("Privates:").Append(Environment.NewLine);

        foreach (var privateSoldier in this.Privates)
        {
            sb.Append("  ").Append(privateSoldier.ToString());
        }

        return sb.ToString();
    } 
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    private IDictionary<string, int> repairs;

    public Engineer(string id, string firstName, string lastName, double salary, string corps, IDictionary<string, int> repairs) : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = repairs;
    }

    public IDictionary<string, int> Repairs { get { return this.repairs; } private set { this.repairs = value; } }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}")
            .Append(Environment.NewLine).Append($"Corps: {this.Corps}")
            .Append(Environment.NewLine).Append("Repairs:").Append(Environment.NewLine);

        foreach (var pair in this.Repairs)
        {
            sb.Append("  ").Append($"Part Name: {pair.Key} Hours Worked: {pair.Value}")
                .Append(Environment.NewLine);
        }
        return sb.ToString();
        //        $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}{Environment.NewLine}Corps: {this.Corps}{Environment.NewLine}Repairs: {Environment.NewLine} {string.Join($"{Environment.NewLine} ", this.Repairs.Select(r => r.ToString()))}";
    }
}
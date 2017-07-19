using System;
using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    private IDictionary<string, string> missions;
    public Commando(string id, string firstName, string lastName, double salary, string corps, IDictionary<string, string> missions) : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = missions;
    }

    public IDictionary<string, string> Missions { get { return this.missions; } private set { this.missions = value; } }

    public void CompleteMission(string missionName)
    {
        if (this.Missions.ContainsKey(missionName))
        {
            this.Missions[missionName] = "Finished";
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}")
            .Append(Environment.NewLine).Append($"Corps: {this.Corps}")
            .Append(Environment.NewLine).Append("Missions:").Append(Environment.NewLine);
        
        foreach (var pair in this.Missions)
        {
            sb.Append("  ").Append($"Code Name: {pair.Key} State: {pair.Value}")
                .Append(Environment.NewLine);
        }

        return sb.ToString();
    }
}
using System;
using System.Collections.Generic;

public interface ICommando
{
    IDictionary<string, string> Missions { get; }
    void CompleteMission(string missionName);
}
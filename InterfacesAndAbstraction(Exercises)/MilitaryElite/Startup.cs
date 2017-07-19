using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        string inputLine = Console.ReadLine();
        List<Soldier> soldiers = new List<Soldier>();

        while (inputLine != "End")
        {
            var inputArgs = inputLine.Split();

            switch (inputArgs[0])
            {
                case "Private":
                    Private privateSoldier = new Private(inputArgs[1], inputArgs[2], inputArgs[3], double.Parse(inputArgs[4]));
                    soldiers.Add(privateSoldier);
                    break;
                case "LeutenantGeneral":
                    List<Private> privates = new List<Private>();
                    for (int i = 5; i < inputArgs.Length; i++)
                    {
                        string privateId = inputArgs[i];
                        Private currentPrivate = (Private)soldiers.First(s => s.Id == privateId);
                        privates.Add(currentPrivate);
                    }
                    LeutenantGeneral ltGeneral = new LeutenantGeneral(inputArgs[1], inputArgs[2], inputArgs[3], double.Parse(inputArgs[4]), privates);
                    soldiers.Add(ltGeneral);
                    break;
                case "Engineer":
                    var repairs = new Dictionary<string, int>();
                    for (int i = 6; i < inputArgs.Length; i += 2)
                    {
                        string repairPart = inputArgs[i];
                        int repairHours = int.Parse(inputArgs[i + 1]);
                        repairs.Add(repairPart, repairHours);
                    }
                    try
                    {
                        Soldier engineer = new Engineer(inputArgs[1], inputArgs[2], inputArgs[3], double.Parse(inputArgs[4]), inputArgs[5], repairs);
                        soldiers.Add(engineer);
                    }
                    catch (ArgumentException)
                    {
                    }
                    break;
                case "Commando":
                    IDictionary<string, string> missions = new Dictionary<string, string>();
                    for (int i = 6; i < inputArgs.Length; i += 2)
                    {
                        var missionName = inputArgs[i];
                        var missionState = inputArgs[i + 1];
                        if (missionState == "inProgress" || missionState == "Finished")
                        {
                            missions.Add(missionName, missionState);
                        }
                    }
                    Commando commando = new Commando(inputArgs[1], inputArgs[2], inputArgs[3], double.Parse(inputArgs[4]), inputArgs[5], missions);
                    soldiers.Add(commando);
                    break;
                case "Spy":
                    Spy spy = new Spy(inputArgs[1], inputArgs[2], inputArgs[3], inputArgs[4]);
                    soldiers.Add(spy);
                    break;
            }
            inputLine = Console.ReadLine();
        }
        foreach (var soldier in soldiers)
        {
            Console.Write(soldier.ToString());
        }
    }
}
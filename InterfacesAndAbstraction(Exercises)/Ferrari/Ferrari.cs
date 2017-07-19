using System;

public class Ferrari:ICar
{
    private const string ModelOfCar = "488-Spider";

    public Ferrari(string driver)
    {
        Driver = driver;
        Model = ModelOfCar;
    }

    public string Driver { get; private set; }

    public string Model { get; private set; }

    public string PushGas()
    {
        return "Zadu6avam sA!";
    }

    public string Brake()
    {
        return "Brakes!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.Brake()}/{this.PushGas()}/{this.Driver}";
    }
}
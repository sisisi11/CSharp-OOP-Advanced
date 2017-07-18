using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface ICar
{
    string Model { get; }
    string Color { get; }
    string Start();
    string Stop();

}
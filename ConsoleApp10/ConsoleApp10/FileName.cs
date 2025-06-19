using System;

public class Vehicle
{
    public virtual void DisplayInfo()
    {
        Console.WriteLine("I'm a vehicle.");
    }
}

public class Car : Vehicle
{
    public override void DisplayInfo()
    {
        Console.WriteLine("I'm a car and I drive on 4 wheels :)");
    }
}

public class MotorBike : Vehicle
{
    public override void DisplayInfo()
    {
        Console.WriteLine("I'm a motorbike and I drive on 2 wheels :)");
    }
}

public class Boat : Vehicle
{
    public override void DisplayInfo()
    {
        Console.WriteLine("I'm a boat and I do not have wheels :(");
    }
}

public class Airplane : Vehicle
{
    public override void DisplayInfo()
    {
        Console.WriteLine("I'm a plane I have couple of wheels :)");
    }
}

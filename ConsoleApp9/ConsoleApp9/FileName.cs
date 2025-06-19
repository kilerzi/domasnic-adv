using System;
//public classot
public class Vehicle
{
    //sto ima eden method display info aka ova podplu
    public virtual void DisplayInfo()
    {
        Console.WriteLine("I am a vehicle");
    }
}
//classa car
public class Car : Vehicle
{
    public override void DisplayInfo()
    {
        Console.WriteLine("I'm a car and I drive on 4 wheels :)");
    }
}
//classa motorbike
public class MotorBike : Vehicle
{
    public override void DisplayInfo()
    {
        Console.WriteLine("I'm a motorbike and I drive on 2 wheels :)");
    }
}
//classa boat
public class Boat : Vehicle
{
    public override void DisplayInfo()
    {
        Console.WriteLine("I'm a boat and I do not have wheels :(");
    }
}
//clasa vehicle
public class Airplane : Vehicle
{
    public override void DisplayInfo()
    {
        Console.WriteLine("I'm a plane I have couple of wheels :)");
    }
}

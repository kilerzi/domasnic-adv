using System;
//exctentions so functions
public static class VehicleExtensions
{
    //car drive metod
    public static void Drive(this Car car)
    {
        Console.WriteLine("The car is driving");
    }
    //motor bike wheeling method
    public static void Wheelie(this MotorBike bike)
    {
        Console.WriteLine("The motorbike is driving on one wheel");
    }
    //boat sail method
    public static void Sail(this Boat boat)
    {
        Console.WriteLine("The boat is sailing");
    }
    //plane flying metod
    public static void Fly(this Airplane plane)
    {
        Console.WriteLine("The airplane is flying");
    }
}

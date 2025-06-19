using System;
using System.Linq;
using System.Collections.Generic;

namespace NewCarHomework
{
    public class Car
    {
        public string Model { get; set; }
        public double MilesPerGalon { get; set; }
        public int Cylinders { get; set; }
        public double HorsePower { get; set; }
        public double Weight { get; set; }

        
        public double AccelerationTime { get; set; }
        public string Origin { get; set; }
    }

    public static class CarsData
    {
        public static List<Car> Cars;

        static CarsData()
        {
            LoadCars();
        }

        public static void LoadCars()
        {
            Cars = new List<Car>()
            {
                new Car() { Model = "Chevrolet Chevelle Malibu", MilesPerGalon = 18, AccelerationTime = 12, Cylinders = 8, HorsePower = 130, Origin = "US", Weight = 3504 },
                new Car() { Model = "Buick Skylark 320", MilesPerGalon = 15, AccelerationTime = 11.5, Cylinders = 8, HorsePower = 165, Origin = "US", Weight = 3693 },
                new Car() { Model = "Plymouth Satellite", MilesPerGalon = 18, AccelerationTime = 11, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 3436 },
                new Car() { Model = "AMC Rebel SST", MilesPerGalon = 16, AccelerationTime = 12, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 3433 },
                new Car() { Model = "Ford Torino", MilesPerGalon = 17, AccelerationTime = 10.5, Cylinders = 8, HorsePower = 140, Origin = "US", Weight = 3449 },
                new Car() { Model = "Toyota Corolla Mark ii", MilesPerGalon = 24, AccelerationTime = 15, Cylinders = 4, HorsePower = 95, Origin = "Japan", Weight = 2372 },
                new Car() { Model = "Volkswagen 1131 Deluxe Sedan", MilesPerGalon = 26, AccelerationTime = 20.5, Cylinders = 4, HorsePower = 46, Origin = "Europe", Weight = 1835 },
                // dodadi gi drugite koli tuka 
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cars = CarsData.Cars;

            // 1. izberi horsepower na US avtomobili so horsepower pogolem od 150.
            var hpUsCarsOver150 = cars.Where(c => c.Origin == "US" && c.HorsePower > 150).Select(c => c.HorsePower);
            Console.WriteLine("Horsepower na US avtomobili so > 150 HP:");
            foreach (var hp in hpUsCarsOver150) Console.WriteLine(hp);

            // 2. izberi tezina na Evropski avtomobili so horsepower pomal od 100.
            var weightEuCarsUnder100HP = cars.Where(c => c.Origin == "Europe" && c.HorsePower < 100).Select(c => c.Weight);
            Console.WriteLine("\nTezina na Evropski avtomobili so < 100 HP:");
            foreach (var w in weightEuCarsUnder100HP) Console.WriteLine(w);

            // 3. izberi poteklo na Japonski avtomobili koi tezhat pomalku od 2200.
            var originJapCarsLight = cars.Where(c => c.Origin == "Japan" && c.Weight < 2200).Select(c => c.Origin);
            Console.WriteLine("\nPoteklo na Japonski avtomobili so tezina < 2200:");
            foreach (var origin in originJapCarsLight) Console.WriteLine(origin);

            // 4. izberi broj na cilindri na US avtomobili so tocen broj cilindri 8.
            var cylCountUsCars8 = cars.Where(c => c.Origin == "US" && c.Cylinders == 8).Select(c => c.Cylinders);
            Console.WriteLine("\nBroj na cilindri na US avtomobili so tocno 8 cilindri:");
            foreach (var cyl in cylCountUsCars8) Console.WriteLine(cyl);

            // 5. izberi miles per gallon na avtomobili so povekje od 25 mpg i vreme na ubrzuvanje povisoko od 15 sekundi.
            var mpgCarsOver25AccOver15 = cars.Where(c => c.MilesPerGalon > 25 && c.AccelerationTime > 15).Select(c => c.MilesPerGalon);
            Console.WriteLine("\nMiles per gallon na avtomobili so > 25 mpg i ubrzuvanje > 15s:");
            foreach (var mpg in mpgCarsOver25AccOver15) Console.WriteLine(mpg);

            // 6. zemete vreme na ubrzuvanje na posledniot 4-cilindricen avtomobil so vreme na ubrzuvanje pod 15 sekundi.
            var last4CylAccUnder15 = cars.Where(c => c.Cylinders == 4 && c.AccelerationTime < 15).OrderBy(c => c.AccelerationTime).LastOrDefault()?.AccelerationTime;
            Console.WriteLine($"\nVreme na ubrzuvanje na posledniot 4-cilindricen avtomobil so ubrzuvanje pod 15s: {last4CylAccUnder15}");

            // 7. zemete ime na modelot na prviot avtomobil so 0 horsepower.
            var firstZeroHpCarModel = cars.FirstOrDefault(c => c.HorsePower == 0)?.Model;
            Console.WriteLine($"\nIme na modelot na prviot avtomobil so 0 horsepower: {firstZeroHpCarModel}");

            // 8. zemete tezina na posledniot Japonski avtomobil so horsepower povisok od 90.
            var lastJapCarOver90HPWeight = cars.Where(c => c.Origin == "Japan" && c.HorsePower > 90).LastOrDefault()?.Weight;
            Console.WriteLine($"\nTezina na posledniot Japonski avtomobil so > 90 HP: {lastJapCarOver90HPWeight}");

            // 9. zemete horsepower na prviot US avtomobil so tezina pogolema od 4000 i pomal broj cilindri od 6.
            var firstUsCarWeightOver4000Under6CylHP = cars.Where(c => c.Origin == "US" && c.Weight > 4000 && c.Cylinders < 6).Select(c => c.HorsePower).FirstOrDefault();
            Console.WriteLine($"\nHorsepower na prviot US avtomobil so tezina > 4000 i < 6 cilindri: {firstUsCarWeightOver4000Under6CylHP}");

            // 10. zemete poteklo na posledniot avtomobil so vreme na ubrzuvanje pogolemo od 20 sekundi.
            var lastCarAccOver20Origin = cars.Where(c => c.AccelerationTime > 20).LastOrDefault()?.Origin;
            Console.WriteLine($"\nPoteklo na posledniot avtomobil so vreme na ubrzuvanje > 20s: {lastCarAccOver20Origin}");
        }
    }
}

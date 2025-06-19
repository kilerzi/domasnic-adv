using System;
using System.Linq;
using System.Collections.Generic;

namespace CarLinqQueries
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
            Cars = new List<Car>
            {
                new Car { Model = "Chevrolet Chevelle Malibu", MilesPerGalon = 18, Cylinders = 8, HorsePower = 130, Weight = 3504, AccelerationTime = 12, Origin = "US" },
                new Car { Model = "Buick Skylark 320", MilesPerGalon = 15, Cylinders = 8, HorsePower = 165, Weight = 3693, AccelerationTime = 11.5, Origin = "US" },
                new Car { Model = "Citroen DS-21 Pallas", MilesPerGalon = 0, Cylinders = 4, HorsePower = 115, Weight = 3090, AccelerationTime = 17.5, Origin = "Europe" },
                new Car { Model = "Toyota Corolla", MilesPerGalon = 24, Cylinders = 4, HorsePower = 95, Weight = 2228, AccelerationTime = 14, Origin = "Japan" },
                new Car { Model = "Volkswagen 1131 Deluxe Sedan", MilesPerGalon = 26, Cylinders = 4, HorsePower = 46, Weight = 1835, AccelerationTime = 20.5, Origin = "Europe" },
                new Car { Model = "Ford Galaxie 500", MilesPerGalon = 15, Cylinders = 8, HorsePower = 198, Weight = 4341, AccelerationTime = 10, Origin = "US" },
                new Car { Model = "Chevrolet Impala", MilesPerGalon = 14, Cylinders = 8, HorsePower = 220, Weight = 4354, AccelerationTime = 9, Origin = "US" }
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Car data loaded. Total cars: " + CarsData.Cars.Count);

            // 1. filterni site koli od europe
            var europeanCars = CarsData.Cars.Where(car => car.Origin == "Europe").ToList();
            Console.WriteLine("\nEuropean Cars:");
            foreach (var car in europeanCars)
                Console.WriteLine($"- {car.Model} ({car.Origin})");

            // 2. najdi unique cylinders in the car
            var uniqueCylinders = CarsData.Cars.Select(car => car.Cylinders).Distinct().ToList();
            Console.WriteLine("\nUnique Cylinders:");
            foreach (var cyl in uniqueCylinders)
                Console.WriteLine($"- {cyl}");

            // 3. izberi site iminja na avtomoboli so nivnite modeli i konvertnigi na golemi
            var upperCaseModels = CarsData.Cars.Select(car => car.Model.ToUpper()).ToList();
            Console.WriteLine("\nCar Models in Uppercase:");
            foreach (var model in upperCaseModels)
                Console.WriteLine($"- {model}");

            // 4.nad 300 horsepower
            bool hasHighHorsepower = CarsData.Cars.Any(car => car.HorsePower > 300);
            Console.WriteLine($"\nAny car with HP > 300? {hasHighHorsepower}");

            // 5. highest horsepower car
            var carWithHighestHP = CarsData.Cars.OrderByDescending(car => car.HorsePower).FirstOrDefault();
            if (carWithHighestHP != null)
                Console.WriteLine($"\nCar with highest HP: {carWithHighestHP.Model} ({carWithHighestHP.HorsePower} HP)");

            // 6.site chevrolet i naredigi po tezini po opagacki redosled
            var chevroletCars = CarsData.Cars.Where(car => car.Model.StartsWith("Chevrolet")).OrderByDescending(car => car.Weight).ToList();
            Console.WriteLine("\nChevrolet Cars by Weight:");
            foreach (var car in chevroletCars)
                Console.WriteLine($"- {car.Model}, Weight: {car.Weight}");

            // 7. longest model name
            var carWithLongestName = CarsData.Cars.OrderByDescending(car => car.Model.Length).FirstOrDefault();
            if (carWithLongestName != null)
                Console.WriteLine($"\nCar with longest model name: {carWithLongestName.Model}");

            // 8.grupiraj gi avtomobilite po poteklo i potoa naredi gi spored brojot na avtomobili
            var groupedByOrigin = CarsData.Cars.GroupBy(car => car.Origin).OrderBy(g => g.Count()).ToList();
            Console.WriteLine("\nCars grouped by Origin:");
            foreach (var group in groupedByOrigin)
                Console.WriteLine($"- {group.Key}: {group.Count()} cars");

            // 9.5 highest horsepower koli
            var top5Horsepower = CarsData.Cars.OrderByDescending(car => car.HorsePower).Take(5).ToList();
            Console.WriteLine("\nTop 5 Cars by Horsepower:");
            foreach (var car in top5Horsepower)
                Console.WriteLine($"- {car.Model} ({car.HorsePower} HP)");

            // 10. najgolem accelitatiopn time
            var slowestAcceleratingCar = CarsData.Cars.OrderByDescending(car => car.AccelerationTime).FirstOrDefault();
            if (slowestAcceleratingCar != null)
                Console.WriteLine($"\nSlowest acceleration car: {slowestAcceleratingCar.Model} ({slowestAcceleratingCar.AccelerationTime} s)");

            // 11. izberi samomo model i moknost na avtomobili sto imaat poise od 200 hp
            var powerfulCars = CarsData.Cars.Where(car => car.HorsePower > 200)
                                           .Select(car => new { car.Model, car.HorsePower }).ToList();
            Console.WriteLine("\nCars with HP > 200:");
            foreach (var car in powerfulCars)
                Console.WriteLine($"- {car.Model} ({car.HorsePower} HP)");

            // 12. unikatni potekla nba avtomobilite 
            var uniqueOrigins = CarsData.Cars.Select(car => car.Origin).Distinct().OrderBy(origin => origin).ToList();
            Console.WriteLine("\nUnique Origins:");
            foreach (var origin in uniqueOrigins)
                Console.WriteLine($"- {origin}");

            // 13. koli so poise od 4 cilindi i naredi gi prvo po potoklo
            var carsWithMoreThan4Cylinders = CarsData.Cars.Where(car => car.Cylinders > 4)
                                                          .OrderBy(car => car.Origin)
                                                          .ThenBy(car => car.HorsePower).ToList();
            Console.WriteLine("\nCars with more than 4 cylinders:");
            foreach (var car in carsWithMoreThan4Cylinders)
                Console.WriteLine($"- {car.Model} ({car.Origin}, {car.HorsePower} HP)");

            // 14. filtriraj gi site avtomobili koi imaat povekje od 6 cilindri bez da vklucuvas 6 a potoa site avtomobili koi imaat to;no 4 i moknost pogolema od 110,
            var moreThan6Cylinders = CarsData.Cars.Where(car => car.Cylinders > 6);
            var fourCylindersHighHP = CarsData.Cars.Where(car => car.Cylinders == 4 && car.HorsePower > 110);
            var joinedResults = moreThan6Cylinders.Concat(fourCylindersHighHP).ToList();
            Console.WriteLine("\nCars with >6 cylinders or 4 cylinders & HP > 110:");
            foreach (var car in joinedResults)
                Console.WriteLine($"- {car.Model} ({car.Cylinders} cylinders, {car.HorsePower} HP)");

            // 15. filtriraj koli poveke od 200 hp i pronajdi najnisko i najvisoko i proseno potrosuvawe
            var highHorsepowerCars = CarsData.Cars.Where(car => car.HorsePower > 200 && car.MilesPerGalon > 0);
            if (highHorsepowerCars.Any())
            {
                var minMpg = highHorsepowerCars.Min(car => car.MilesPerGalon);
                var maxMpg = highHorsepowerCars.Max(car => car.MilesPerGalon);
                var avgMpg = highHorsepowerCars.Average(car => car.MilesPerGalon);
                Console.WriteLine($"\nFor cars with HP > 200:");
                Console.WriteLine($"- Min MPG: {minMpg}");
                Console.WriteLine($"- Max MPG: {maxMpg}");
                Console.WriteLine($"- Avg MPG: {avgMpg:F2}");
            }
            else
            {
                Console.WriteLine("\nNo cars found with HP > 200 and valid MPG.");
            }
        }
    }
}

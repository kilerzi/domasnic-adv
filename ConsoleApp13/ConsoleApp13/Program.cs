using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    const string FolderName = "Files";
    const string NamesFileName = "names.txt";

    static void Main()
    {
        // task 1: kreiraj folder i fajl
        CreateFolderAndFile();

        // task 2: procitaj names.txt, pobaraj od korisnik da vnese iminja i zacuvaj gi vo fajlot
        AddNamesToFile();

        // task 3 i 4: filtriraj iminja po prva bukva i zacuvaj gi vo odvojni fajlovi, ako fajlot veche postoi dodadi gi novite iminja
        FilterNamesByLetterAndSave();
    }

    static void CreateFolderAndFile()
    {
        if (!Directory.Exists(FolderName))
        {
            Directory.CreateDirectory(FolderName);
            Console.WriteLine($"Folder '{FolderName}' kreiran.");
        }
        else
        {
            Console.WriteLine($"Folder '{FolderName}' veche postoi.");
        }

        string filePath = Path.Combine(FolderName, NamesFileName);
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close(); // zatvori za osloboduvanje na handle
            Console.WriteLine($"Fajl '{NamesFileName}' kreiran vo folder '{FolderName}'.");
        }
        else
        {
            Console.WriteLine($"Fajl '{NamesFileName}' veche postoi vo folder '{FolderName}'.");
        }
    }

    static void AddNamesToFile()
    {
        string filePath = Path.Combine(FolderName, NamesFileName);

        Console.WriteLine("Vnesi iminja odvoeni so zarez (na primer: John, Alice, Bob):");
        string input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
        {
            // razdeli iminjata, izbrishi praznini, izbrishi prazni vnatre
            var names = input.Split(',')
                             .Select(n => n.Trim())
                             .Where(n => !string.IsNullOrWhiteSpace(n))
                             .ToList();

            // dodadi iminjata na kraj od fajlot
            File.AppendAllLines(filePath, names);
            Console.WriteLine($"{names.Count} iminja dodadeni vo '{NamesFileName}'.");
        }
        else
        {
            Console.WriteLine("Ne se vneseni iminja.");
        }
    }

    static void FilterNamesByLetterAndSave()
    {
        string filePath = Path.Combine(FolderName, NamesFileName);

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Fajlot '{NamesFileName}' ne postoi. Ne moze da se filtrira.");
            return;
        }

        var allNames = File.ReadAllLines(filePath)
                           .Select(n => n.Trim())
                           .Where(n => !string.IsNullOrWhiteSpace(n))
                           .ToList();

        if (allNames.Count == 0)
        {
            Console.WriteLine("Nema iminja vo fajlot za filtriranje.");
            return;
        }

        // bukvi od A do Z
        for (char letter = 'A'; letter <= 'Z'; letter++)
        {
            // filtriraj iminja koi pocnuvaat so tekovnata bukva (bez razlika megju golemi i mali bukvi)
            var filteredNames = allNames
                .Where(name => name.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase))
                .Distinct()
                .ToList();

            if (filteredNames.Count > 0)
            {
                string filteredFileName = $"namesStartingWith_{letter}.txt";
                string filteredFilePath = Path.Combine(FolderName, filteredFileName);

                if (File.Exists(filteredFilePath))
                {
                    // task 4: dodadi novi iminja vo postoecki fajl, izbegni duplikati
                    var existingNames = File.ReadAllLines(filteredFilePath)
                                            .Select(n => n.Trim())
                                            .Where(n => !string.IsNullOrWhiteSpace(n))
                                            .ToHashSet(StringComparer.OrdinalIgnoreCase);

                    var newNamesToAdd = filteredNames
                        .Where(n => !existingNames.Contains(n))
                        .ToList();

                    if (newNamesToAdd.Count > 0)
                    {
                        File.AppendAllLines(filteredFilePath, newNamesToAdd);
                        Console.WriteLine($"Dodadeni {newNamesToAdd.Count} novi iminja vo '{filteredFileName}'.");
                    }
                    else
                    {
                        Console.WriteLine($"Nema novi iminja za dodavanje vo '{filteredFileName}'.");
                    }
                }
                else
                {
                    // task 3: kreiraj nov fajl so filtrirani iminja
                    File.WriteAllLines(filteredFilePath, filteredNames);
                    Console.WriteLine($"Kreiran fajl '{filteredFileName}' so {filteredNames.Count} iminja.");
                }
            }
            else
            {
                // nema iminja so taa bukva, ne pravi nisto
            }
        }
    }
}

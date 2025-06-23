namespace MotorcycleCatalog
{
    class Motorcycle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int EngineCC { get; set; }
        public int HorsePower { get; set; }
        public int Kilowatts { get; set; }
        public double ZeroToHundred { get; set; }
        public int TopSpeed { get; set; }
        public int Price { get; set; }

        public Motorcycle(string brand, string model, int year, int engineCC, int horsePower, int kilowatts, double zeroToHundred, int topSpeed, int price)
        {
            Brand = brand;
            Model = model;
            Year = year;
            EngineCC = engineCC;
            HorsePower = horsePower;
            Kilowatts = kilowatts;
            ZeroToHundred = zeroToHundred;
            TopSpeed = topSpeed;
            Price = price;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"\n--- {Brand} {Model} ---");
            Console.WriteLine($"Year         : {Year}");
            Console.WriteLine($"Engine       : {EngineCC} cc");
            Console.WriteLine($"Power        : {HorsePower} HP / {Kilowatts} kW");
            Console.WriteLine($"0-100 km/h   : {ZeroToHundred} sec");
            Console.WriteLine($"Top Speed    : {TopSpeed} km/h");
            Console.WriteLine($"Price        : {Price} лв");
            Console.WriteLine("--------------------------\n");
        }
    }

    class Program
    {
        static Dictionary<string, List<Motorcycle>> catalog = new Dictionary<string, List<Motorcycle>>();

        static void Main()
        {
            InitializeCatalog();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MOTORCYCLE CATALOG ===\n");
                Console.WriteLine("1. Browse Catalog");
                Console.WriteLine("2. Compare Motorcycles");
                Console.WriteLine("0. Exit");

                Console.Write("\nYour choice: ");
                string menuChoice = Console.ReadLine();

                if (menuChoice == "0") break;

                switch (menuChoice)
                {
                    case "1":
                        BrowseCatalog();
                        break;
                    case "2":
                        CompareMotorcycles();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void InitializeCatalog()
        {
            catalog["Kawasaki"] = new List<Motorcycle>
            {
                new Motorcycle("Kawasaki", "H2R", 2023, 998, 310, 231, 2.5, 400, 106375),
                new Motorcycle("Kawasaki", "ZX-10R", 2023, 998, 203, 151, 2.8, 300, 32900),
                new Motorcycle("Kawasaki", "ZX-6R", 2023, 636, 130, 97, 3.0, 260, 19675)
            };

            catalog["BMW"] = new List<Motorcycle>
            {
                new Motorcycle("BMW", "M1000RR", 2023, 999, 212, 158, 3.0, 300, 78250),
                new Motorcycle("BMW", "S1000RR", 2009, 999, 193, 144, 3.1, 299, 26825)
            };

            catalog["Honda"] = new List<Motorcycle>
            {
                new Motorcycle("Honda", "CBR1000RR Fireblade", 2023, 999, 214, 160, 3.0, 299, 34225),
                new Motorcycle("Honda", "CBR600RR", 2023, 599, 113, 84, 3.5, 260, 23225),
                new Motorcycle("Honda", "VTR1000 (Superhawk)", 2003, 996, 100, 75, 3.7, 240, 9250)
            };

            catalog["Yamaha"] = new List<Motorcycle>
            {
                new Motorcycle("Yamaha", "YZF-R1", 2023, 998, 200, 149, 3.0, 299, 32900),
                new Motorcycle("Yamaha", "R6", 2020, 599, 119, 89, 3.3, 260, 23225),
                new Motorcycle("Yamaha", "R1 GYTR", 2023, 998, 221, 165, 2.9, 299, 48000)
            };

            catalog["Suzuki"] = new List<Motorcycle>
            {
                new Motorcycle("Suzuki", "GSX-R1000", 2023, 999, 199, 148, 3.0, 299, 28175),
                new Motorcycle("Suzuki", "Hayabusa 1300", 2023, 1340, 187, 140, 2.8, 312, 34225),
                new Motorcycle("Suzuki", "GSX-R600 K8", 2008, 599, 104, 78, 3.7, 260, 10175)
            };

            catalog["Ducati"] = new List<Motorcycle>
            {
                new Motorcycle("Ducati", "Panigale V4R", 2023, 998, 221, 165, 3.0, 300, 78250),
                new Motorcycle("Ducati", "Superleggera V4", 2023, 998, 234, 175, 2.8, 300, 157250),
                new Motorcycle("Ducati", "600 SS", 1998, 583, 72, 54, 4.5, 220, 6450)
            };
        }

        static void BrowseCatalog()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== BROWSE CATALOG ===\n");

                int index = 1;
                Dictionary<int, string> brandMap = new Dictionary<int, string>();
                foreach (var brand in catalog.Keys)
                {
                    Console.WriteLine($"{index}. {brand}");
                    brandMap[index] = brand;
                    index++;
                }

                Console.WriteLine("0. Back");
                Console.Write("\nChoose brand number: ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice == 0)
                    break;

                if (brandMap.ContainsKey(choice))
                {
                    string selectedBrand = brandMap[choice];
                    Console.Clear();
                    Console.WriteLine($"--- Models of {selectedBrand} ---");

                    var models = catalog[selectedBrand];
                    for (int i = 0; i < models.Count; i++)
                        Console.WriteLine($"{i + 1}. {models[i].Model}");

                    Console.Write("\nSelect a model number to see details: ");
                    if (int.TryParse(Console.ReadLine(), out int modelIndex) &&
                        modelIndex >= 1 && modelIndex <= models.Count)
                    {
                        models[modelIndex - 1].DisplayDetails();
                        Console.WriteLine("Press Enter to return...");
                        Console.ReadLine();
                    }
                }
            }
        }

        static Motorcycle SelectMotorcycle(string prompt)
        {
            Console.WriteLine($"\n{prompt}");

            int bIndex = 1;
            Dictionary<int, string> brandMap = new Dictionary<int, string>();
            foreach (var brand in catalog.Keys)
            {
                Console.WriteLine($"{bIndex}. {brand}");
                brandMap[bIndex] = brand;
                bIndex++;
            }

            Console.Write("Select brand: ");
            if (!int.TryParse(Console.ReadLine(), out int brandChoice) || !brandMap.ContainsKey(brandChoice))
                return null;

            string selectedBrand = brandMap[brandChoice];
            var models = catalog[selectedBrand];

            for (int i = 0; i < models.Count; i++)
                Console.WriteLine($"{i + 1}. {models[i].Model}");

            Console.Write("Select model: ");
            if (int.TryParse(Console.ReadLine(), out int modelChoice) &&
                modelChoice >= 1 && modelChoice <= models.Count)
                return models[modelChoice - 1];

            return null;
        }

        static void CompareMotorcycles()
        {
            Console.Clear();
            Console.WriteLine("=== COMPARE MOTORCYCLES ===");

            Motorcycle m1 = SelectMotorcycle("First motorcycle");
            if (m1 == null) return;

            Motorcycle m2 = SelectMotorcycle("Second motorcycle");
            if (m2 == null) return;

            Console.Clear();
            Console.WriteLine("=== COMPARISON RESULT ===\n");

            Console.WriteLine("{0,-20} | {1,-25} | {2,-25}", "", m1.Brand + " " + m1.Model, m2.Brand + " " + m2.Model);
            Console.WriteLine(new string('-', 75));
            Console.WriteLine("{0,-20} | {1,-25} | {2,-25}", "Year", m1.Year, m2.Year);
            Console.WriteLine("{0,-20} | {1,-25} | {2,-25}", "Engine (cc)", m1.EngineCC, m2.EngineCC);
            Console.WriteLine("{0,-20} | {1,-25} | {2,-25}", "HP", m1.HorsePower, m2.HorsePower);
            Console.WriteLine("{0,-20} | {1,-25} | {2,-25}", "kW", m1.Kilowatts, m2.Kilowatts);
            Console.WriteLine("{0,-20} | {1,-25} | {2,-25}", "0–100 km/h", $"{m1.ZeroToHundred} sec", $"{m2.ZeroToHundred} sec");
            Console.WriteLine("{0,-20} | {1,-25} | {2,-25}", "Top Speed", $"{m1.TopSpeed} km/h", $"{m2.TopSpeed} km/h");
            Console.WriteLine("{0,-20} | {1,-25} | {2,-25}", "Price", $"{m1.Price} лв", $"{m2.Price} лв");

            Console.WriteLine("\nPress Enter to return...");
            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp7
{
    class Program
    {
        //enum se koristi da imenuvas konstanti
        public enum ProductCategory
        {
            Smartphones = 1,
            Laptops = 2,
            Fragrances = 3,
            Skincare = 4,
            Groceries = 5,
            HomeDecoration = 6
        }

        public class Product
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public double Price { get; set; }
            public double Rating { get; set; }
            public int Stock { get; set; }
            public string Brand { get; set; }
            public ProductCategory Category { get; set; }

            public Product(int id, string title, string description, double price, double rating, int stock, string brand, ProductCategory category)
            {
                Id = id;
                Title = title;
                Description = description;
                Price = price;
                Rating = rating;
                Stock = stock;
                Brand = brand;
                Category = category;
            }
        }

        public class ProductDetails
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public double Price { get; set; }
        }
        //podatocite sto se dadeni od vas
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product(1, "iPhone 9", "An apple mobile which is nothing like apple", 549, 4.69, 94, "Apple", ProductCategory.Smartphones),
                new Product(2, "iPhone X", "SIM-Free, Model A19211 6.5-inch Super Retina HD...", 899, 4.44, 34, "Apple", ProductCategory.Smartphones),
                new Product(3, "Samsung Universe 9", "Samsung's new variant...", 1249, 4.09, 36, "Samsung", ProductCategory.Smartphones),
                new Product(4, "OPPOF19", "OPPO F19 is officially announced...", 280, 4.3, 123, "OPPO", ProductCategory.Smartphones),
                new Product(5, "Huawei P30", "Huawei’s re-badged P30 Pro...", 499, 4.09, 32, "Huawei", ProductCategory.Smartphones),
                new Product(6, "MacBook Pro", "MacBook Pro 2021...", 1749, 4.57, 83, "Apple", ProductCategory.Laptops),
                new Product(7, "Samsung Galaxy Book", "Samsung Galaxy Book S...", 1499, 4.25, 50, "Samsung", ProductCategory.Laptops),
                new Product(8, "Microsoft Surface Laptop 4", "Style and speed...", 1499, 4.43, 68, "Microsoft Surface", ProductCategory.Laptops),
                new Product(9, "Infinix INBOOK", "Infinix Inbook X1...", 1099, 4.54, 96, "Infinix", ProductCategory.Laptops),
                new Product(10, "HP Pavilion 15-DK1056WM", "HP Pavilion Gaming Laptop...", 1099, 4.43, 89, "HP Pavilion", ProductCategory.Laptops),
                new Product(11, "perfume Oil", "Impression of Acqua Di Gio...", 13, 4.26, 65, "Impression of Acqua Di Gio", ProductCategory.Fragrances),
                new Product(12, "Brown Perfume", "Royal_Mirage Sport...", 40, 4.0, 52, "Royal-Mirage", ProductCategory.Fragrances),
                new Product(13, "Fog Scent Xpressio Perfume", "Fog Scent Xpressio...", 13, 4.59, 61, "Fog Scent Xpressio", ProductCategory.Fragrances),
                new Product(14, "Non-Alcoholic Perfume Oil", "Original Al Munakh...", 120, 4.21, 114, "Al Munakh", ProductCategory.Fragrances),
                new Product(15, "Eau De Perfume Spray", "Genuine Al-Rehab...", 30, 4.7, 105, "Lord - Al-Rehab", ProductCategory.Fragrances),
                new Product(16, "Hyaluronic Acid Serum", "L'Oréal Paris...", 19, 4.83, 110, "L'Oreal Paris", ProductCategory.Skincare),
                new Product(17, "Tree Oil 30ml", "Tea tree oil...", 12, 4.52, 78, "Hemani Tea", ProductCategory.Skincare),
                new Product(18, "Oil Free Moisturizer", "Dermive Oil Free...", 40, 4.56, 88, "Dermive", ProductCategory.Skincare),
                new Product(19, "Skin Beauty Serum", "rorec collagen serum...", 46, 4.42, 54, "ROREC White Rice", ProductCategory.Skincare),
                new Product(20, "Freckle Treatment Cream", "Fair & Clear Freckle cream...", 70, 4.06, 140, "Fair & Clear", ProductCategory.Skincare),
                new Product(21, "Daal Masoor", "Fine quality product...", 20, 4.44, 133, "Saaf & Khaas", ProductCategory.Groceries),
                new Product(22, "Elbow Macaroni", "Bake Parlor Big...", 14, 4.57, 146, "Bake Parlor Big", ProductCategory.Groceries),
                new Product(23, "Orange Essence", "Orange Essence Flavour...", 14, 4.85, 26, "Baking Food Items", ProductCategory.Groceries)
            };

        
            //site smarthphone titles
            IEnumerable<string> smartphones = products
                .Where(p => p.Category == ProductCategory.Smartphones)
                .Select(p => p.Title);
            Console.WriteLine("1. Smartphones:");
            foreach (string title in smartphones) Console.WriteLine(title);

       
            //site product titles
            IEnumerable<string> allTitles = products.Select(p => p.Title);
            Console.WriteLine("\n2. All Product Titles:");
            foreach (string title in allTitles) Console.WriteLine(title);

         
            //site producti nad 4.5
            IEnumerable<Product> highRated = products.Where(p => p.Rating > 4.5);
            Console.WriteLine("\n3. Products with Rating > 4.5:");
            foreach (Product p in highRated) Console.WriteLine($"{p.Title} - Rating: {p.Rating}");

        
            //dropukti so poise od 50 u stock
            IEnumerable<Product> lowStock = products.Where(p => p.Stock < 50);
            Console.WriteLine("\n4. Products with Stock < 50:");
            foreach (Product p in lowStock) Console.WriteLine($"{p.Title} - Stock: {p.Stock}");

       
            //apple producti
            IEnumerable<Product> appleProducts = products.Where(p => p.Brand == "Apple");
            Console.WriteLine("\n5. Apple Products:");
            foreach (Product p in appleProducts) Console.WriteLine(p.Title);

         
            //producti so visoka cena
            Product mostExpensive = products.OrderByDescending(p => p.Price).First();
            Console.WriteLine("\n6. Most Expensive Product:");
            Console.WriteLine($"{mostExpensive.Title} - ${mostExpensive.Price}");

           
            //producti so mal rating
            Product lowestRated = products.OrderBy(p => p.Rating).First();
            Console.WriteLine("\n7. Lowest Rated Product:");
            Console.WriteLine($"{lowestRated.Title} - Rating: {lowestRated.Rating}");

        
            //avarage pricot
            double avgPrice = products.Average(p => p.Price);
            Console.WriteLine($"\n8. Average Price: {avgPrice:F2}");

           
            //parfemi
            IEnumerable<Product> perfumes = products.Where(p => p.Title.Contains("Perfume"));
            Console.WriteLine("\n9. Products Containing 'Perfume':");
            foreach (Product p in perfumes) Console.WriteLine(p.Title);

          
            //broj na skin care itemi
            int skincareCount = products.Count(p => p.Category == ProductCategory.Skincare);
            Console.WriteLine($"\n10. Total Skincare Products: {skincareCount}");

       
            //site ceni na producti
            IEnumerable<double> prices = products.Select(p => p.Price);
            Console.WriteLine("\n11. All Product Prices:");
            foreach (double price in prices) Console.WriteLine(price);

         
            //iminja i ceni na producti
            IEnumerable<ProductDetails> details = products.Select(p => new ProductDetails { Id = p.Id, Title = p.Title, Price = p.Price });
            Console.WriteLine("\n12. Product Details (Title + Price):");
            foreach (ProductDetails detail in details) Console.WriteLine($"{detail.Title} - ${detail.Price}");

            
            //producti sto pocnuvaat so s
            IEnumerable<Product> startsWithS = products.Where(p => p.Title.StartsWith("S"));
            Console.WriteLine("\n13. Titles Starting with 'S':");
            foreach (Product p in startsWithS) Console.WriteLine(p.Title);

            //price  descending sort thingy
            IEnumerable<Product> sortedByPrice = products.OrderByDescending(p => p.Price);
            Console.WriteLine("\n14. Products by Price (High to Low):");
            foreach (Product p in sortedByPrice) Console.WriteLine($"{p.Title} - ${p.Price}");

        
            //products sto se poise ili ednakvo na 4 u rating i imaat povekje ili isto od 100 u stock
            IEnumerable<Product> goodStockAndRating = products.Where(p => p.Rating >= 4.0 && p.Stock >= 100);
            Console.WriteLine("\n15. Products with Rating >= 4 and Stock >= 100:");
            foreach (Product p in goodStockAndRating) Console.WriteLine($"{p.Title} - Rating: {p.Rating}, Stock: {p.Stock}");
        }
    }
}

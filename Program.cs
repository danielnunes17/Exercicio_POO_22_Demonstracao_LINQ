
using Exercicio_POO_22_Demonstracao_LINQ.Entities;

public class Program
{
    public static void Print<T>(string message, IEnumerable<T> collection)
    {
        Console.WriteLine(message);
        foreach (T item in collection)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
    public static void Main(string[] args)
    {
        Category category1 = new Category() { ID = 1, Name = "Tools", Tie = 2 };
        Category category2 = new Category() { ID = 2, Name = "Computers", Tie = 1 };
        Category category3 = new Category() { ID = 3, Name = "Electronics", Tie = 1 };

        List<Product> products = new List<Product>()
        {
            new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = category2 },
                new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = category1 },
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = category3 },
                new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = category2},
                new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = category1 },
                new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = category2},
                new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = category3 },
                new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = category3 },
                new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = category2 },
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = category3 },
                new Product() { Id = 11, Name = "Level", Price = 70.0, Category = category1 }
        };
        IEnumerable<Product> result1 = products.Where(p => p.Category.Tie == 1 && p.Price < 900);
        Print("TIER 1 AND PRICE < 900:", result1);

        IEnumerable<string> result2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
        Print("NAMES PRODUCTS TOOLS", result2);

        var result3 = products.Where(p => p.Name[0] == 'C')
            .Select(p => new { p.Name, p.Price, categoryName = p.Category.Name });
        Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT", result3);

        IOrderedEnumerable<Product> result4 = products.Where(p => p.Category.Tie == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
        Print("TIER 1 ORDER BY PRICE THEN BY NAME", result4);

        IEnumerable<Product> result5 = result4.Skip(2).Take(4);
        Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", result5);

        Product result6 = products.FirstOrDefault();
        Console.WriteLine("First or default: " + result6);

        Product result7 = products.Where(x => x.Price < 3000.0).FirstOrDefault();
        Console.WriteLine("First or default: " + result7 + "\n");

        Product result8 = products.Where(x => x.Id == 3).SingleOrDefault();
        Console.WriteLine("Single or default " + result8);

        Product result9 = products.Where(x => x.Id == 30).SingleOrDefault();
        Console.WriteLine("Single or default " + result9 + "\n");

        double result10 = products.Max(x => x.Price);
        Console.WriteLine("Max price: " + result10);

        double result11 = products.Min(x => x.Price);
        Console.WriteLine("Min price: " + result11);

        double result12 = products.Where(p => p.Category.ID == 1).Sum(p => p.Price);
        Console.WriteLine("Category 1 Sum prices: ", result12);

        double result13 = products.Where(p => p.Category.ID == 1).Average(p => p.Price);
        Console.WriteLine("Category 1 Average prices: ", result13);

        double result14 = products.Where(p => p.Category.ID == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average();
        Console.WriteLine("Category 5 Average prices: " + result14);

        double result15 = products.Where(p => p.Category.ID == 1).Select(p => p.Price).Aggregate(0.0, (X, Y) => (X + Y));
        Console.WriteLine("Category 1 aggregate sum: " + result15 + "\n");

        IEnumerable<IGrouping<Category, Product>> result16 = products.GroupBy(p => p.Category);
        foreach (IGrouping<Category, Product> group in result16)
        {
            Console.WriteLine("Category " + group.Key.Name + ":");
            foreach (Product product in group)
                Console.WriteLine(product);
        }


    }
}
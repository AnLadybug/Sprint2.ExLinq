using ConsoleReflection.Model;
using ConsoleReflection.Services;

Console.WriteLine("Hello, World!");
var pr1 = new Product { Id = 1, Name = "Laptop", Price = 999.99m };
var pr2 = new Product { Id = 2, Name = "Desktop", Price = 1299.99m };

ObjectInspector.Inspect(pr1);
ObjectInspector.Inspect(pr2);


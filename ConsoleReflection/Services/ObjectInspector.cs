using System.Reflection;

namespace ConsoleReflection.Services
{
    internal class ObjectInspector
    {
        /// <summary>
        /// выводит имя типа объекта;
        /// перечисляет все свойства с их типами и значениями;
        /// перечисляет все публичные методы с параметрами.
        /// </summary>
        /// <param name="obj"></param>
        public static void Inspect(object obj)
        {
            Type type = obj.GetType();
            Console.WriteLine($"\n=== Инспекция типа {type.Name} ===");
            var properties = type.GetProperties();
            Console.WriteLine("\nСВОЙСТВА:");
            foreach (var prop in properties)
            {
                Console.WriteLine($"\t{prop.Name} ({prop.PropertyType.Name}) = {prop.GetValue(obj)}");
            }
            Console.WriteLine("\nМЕТОДЫ:");
            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                ParameterInfo[] parameters = method.GetParameters();
                Console.Write($"\t{method.ReturnType.Name} {method.Name}");
                Console.WriteLine(
                    $"({string.Join(
                        ", ",
                        parameters.Select(p => $"{p.ParameterType.Name} {p.Name}")
                        )})"
                    );
            }

        }
    }
}

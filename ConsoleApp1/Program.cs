using ConsoleApp1;
using System.Linq.Expressions;
using System.Reflection;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//var courses = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//var r = courses.Skip(7).Take(5);
//Console.WriteLine(r.ToList().Count);


List<string> students =
[
    "1",
    "2",
    "3",
    "4",
    "5"
];

var totalSent = 0;
var chunkSize = 50;
var emailBatches = students.Chunk(chunkSize);

foreach (var emailBatch in emailBatches)
{
    Test.SendEmail(emailBatch, chunkSize);
    totalSent += emailBatch.Length;
    Console.WriteLine($"Отправлено уведомлений: {totalSent}");
}

var courses = new List<Course> {
    new Course { Id = 1, Title = "Введение в C# и .NET", Category = "Programming" },
    new Course { Id = 2, Title = "UX-дизайн: основы и практика", Category = "Design" },
    new Course { Id = 3, Title = "Машинное обучение: практическое введение", Category = "Data Science" },
    new Course { Id = 4, Title = "Финансовая грамотность для начинающих", Category = "Finance" },
    new Course { Id = 5, Title = "Курс по публичным выступлениям", Category = "Personal Development" },
    new Course { Id = 6, Title = "Продвинутый C#: асинхронность и производительность", Category = "Programming" },
    new Course { Id = 7, Title = "ASP.NET Core: создание веб-приложений", Category = "Programming" },
    new Course { Id = 8, Title = "Entity Framework Core: практическое руководство", Category = "Programming" },
    new Course { Id = 9, Title = "Алгоритмы и структуры данных на C#", Category = "Programming" },
    new Course { Id = 10, Title = "Тестирование и TDD в .NET", Category = "Programming" }
};

var result = new List<string>();
result.Add("Отчёт по курсам");

foreach (var course in courses)
{
    if (course.Modules.Count > 0)
    {
        result.Add($"{course.Title}: {course.Modules.Count} модулей");
    }
}

result.Add($"Всего курсов: {result.Count - 1}");


var courseResponse = courses
    .Where(c => c.Modules.Count > 0)
    .Select(c => $"{c.Title}: {c.Modules.Count} модулей")
    .Prepend("Отчёт по курсам")
    .Append($"Всего курсов: {courses.Count - 1}");

var basketResults = courses
    .Aggregate(
        new { TotalPrice = 0m, MaxPrice = 0m, MaxTitle = string.Empty },
        (acc, course) => new
        {
            TotalPrice = acc.TotalPrice + course.Price,
            MaxPrice = course.Price > acc.MaxPrice? course.Price : acc.MaxPrice,
            MaxTitle = course.Price > acc.MaxPrice ? course.Title : acc.MaxTitle
        });


//Ниже фрагмент кода системы управления интернет-магазином. 
//В нём производится выборка пользователей из нужной страны, активных за последние 14 дней,
//у которых сумма оплаченных заказов за три месяца больше некоторого порога.
//Результат группируется по полу, для каждого пола формируется список идентификаторов пользователей. 

//var threeMonthsAgo = DateTime.UtcNow.AddMonths(-3);
//var lastActiveLimit = DateTime.UtcNow.AddDays(-14);

//var users = await db.Users
//    .Where(u => u.Country == "Япония" && u.LastActiveAtUtc >= lastActiveLimit)
//    .Select(u => new
//    {
//        u.Id,
//        u.Gender,
//        SpendLastThreeMonths = u.Orders
//            .Where(o => o.PaidAtUtc >= threeMonthsAgo)
//            .Sum(o => o.TotalAmount)
//    })
//    .Where(x => x.SpendLastThreeMonths >= 300000)
//    .ToListAsync();

//    var result_ = users
//    .GroupBy(x => x.Gender)
//    .ToDictionary(
//        g => g.Key, 
//        g => g.Select(x => x.Id)
//    );

//Напишите код, который вручную (без использования лямбда-символов =>)
//соберёт дерево выражений, эквивалентное предикату p => p.Stock < 10,
//и проверьте с его помощью продукт:

ParameterExpression productParam = Expression.Parameter(typeof(Product), "p");
MemberExpression stockProperty = Expression.Property(productParam, "Stock");
ConstantExpression threshold = Expression.Constant(10);
BinaryExpression comparison = Expression.GreaterThan(stockProperty, threshold);
Expression<Func<Product, bool>> lambda = Expression.Lambda<Func<Product, bool>>(comparison, productParam);

Console.WriteLine($"Выражение: {lambda}");

var compiled = lambda.Compile();
var cheapProduct = new Product { Name = "Laptop", Stock = 5 };

Console.WriteLine($"Результат для Stock=5: {compiled(cheapProduct)}");
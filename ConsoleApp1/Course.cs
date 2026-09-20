using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }                 // Название курса
        public string Description { get; set; }           // Краткое описание
        public string Category { get; set; }              // Категория/тег курса
        public decimal Price { get; set; }                // Цена (0 — бесплатный)
        public DateTime CreatedAt { get; set; }           // Дата создания курса
        public DateTime? PublishedAt { get; set; }        // Дата публикации (null — черновик)
        public bool IsPublished => PublishedAt.HasValue;

        // Навигационные свойства
        public List<Module> Modules { get; set; } = new();
        //public List<CourseInstructor> Instructors { get; set; } = new();
    }
}

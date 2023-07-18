using PR22.Models.Decanat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR22.Services.Students
{
    static class TestData
    {
        public static IEnumerable<Group> Groups { get; } = Enumerable
        .Range(1, 10)
            .Select(i => new Group { Name = $"Группа {i}" });

        public static Student[] Students { get; } = CreateStudents(Groups);

        private static Student[] CreateStudents(IEnumerable<Group> groups)
        {
            var rnd = new Random();
            int index = 1;
            var students = new List<Student>(100);
            foreach (var group in groups)
            {
                for (var i = 0; i < 10; i++)
                {
                    group.Students.Add(new Student
                    {
                        Name = $"Имя {index}",
                        Surname = $"Фамилия {index}",
                        Patronymic = $"Отчество {index++}",
                        Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(300 * rnd.Next(19, 30))),
                        Rating = rnd.Next() * 100
                    });
                }
            }
            return groups.SelectMany(g => g.Students).ToArray();
        }
    }
}

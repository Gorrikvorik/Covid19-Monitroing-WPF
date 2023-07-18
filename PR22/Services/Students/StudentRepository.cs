using PR22.Models.Decanat;
using PR22.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR22.Services.Students
{

    internal class StudentRepository : RepositoryInMemory<Student>
    {
        protected override void Update(Student source, Student Destination)
        {
            Destination.Name = source.Name;
            Destination.Surname = source.Surname;
            Destination.Patronymic = source.Patronymic;
            Destination.Birthday = source.Birthday;
            Destination.Rating = source.Rating;
        }
    }
}

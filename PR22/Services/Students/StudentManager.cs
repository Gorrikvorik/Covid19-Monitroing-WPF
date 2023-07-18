using PR22.Models.Decanat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR22.Services.Students
{
    class StudentManager
    {
        private readonly StudentRepository _Students;
        private readonly GroupRepository _Groups;

        public IEnumerable<Student> Students => _Students.GetAll();
        public IEnumerable<Group> Groups => _Groups.GetAll();

        public StudentManager(StudentRepository Students, GroupRepository Groups)
        {
            _Students = Students;
            _Groups = Groups;
        }
    }
}

using PR22.Models.Decanat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR22.Services.Students
{
    class _StudentManager
    {
        private readonly StudentRepository _Students;
        private readonly GroupRepository _Groups;

        public IEnumerable<Student> Students => _Students.GetAll();
        public IEnumerable<Group> Groups => _Groups.GetAll();

        public _StudentManager(StudentRepository Students, GroupRepository Groups)
        {
            _Students = Students;
            _Groups = Groups;
        }

        public void Update(Student student) => _Students.Update(student.Id,student);

        public bool Create(Student student,string GroupName)
        {
            if (student is null) throw new ArgumentNullException(nameof(Student));
            if (string.IsNullOrEmpty(GroupName)) throw new ArgumentException("Неккореткное имя группы", nameof(GroupName));
            var group = _Groups.Get(GroupName);
            if(group is null)
            {
                group = new Group() { Name = GroupName };
                _Groups.Add(group);
            }
            group.Students.Add(student);
            _Students.Add(student);
            return true;
        }
    }
}

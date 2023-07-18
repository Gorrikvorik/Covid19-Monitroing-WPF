using PR22.Models.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR22.Models.Decanat
{
    internal class Student : IEntity
    {
        public string Name{ get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public double Rating { get; set; }

        public string Description { get; set; }
        public int Id { get; set; }
    }
}

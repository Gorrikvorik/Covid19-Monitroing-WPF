using PR22.Models.Interfaces;
using System.Collections.Generic;

namespace PR22.Models.Decanat
{
    internal class Group : IEntity
    {
        public string? Name { get; set; }

        public IList<Student>? Students { get; set; }

        public string? Description { get; set; }
        public int Id { get; set; }
    }
}

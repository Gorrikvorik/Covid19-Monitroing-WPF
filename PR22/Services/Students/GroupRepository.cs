using PR22.Models.Decanat;
using PR22.Services.Base;
using System.Linq;

namespace PR22.Services.Students
{
    class GroupRepository : RepositoryInMemory<Group>
    {
        public GroupRepository() :base(TestData.Groups)
        {

        }
        protected override void Update(Group source, Group Destination)
        {
            Destination.Name = source.Name;
            Destination.Description = source.Description;


        }

        public Group Get(string GroupName) => GetAll().FirstOrDefault(g => g.Name == GroupName);
    }
}

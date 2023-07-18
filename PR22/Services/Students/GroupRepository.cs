using PR22.Models.Decanat;
using PR22.Services.Base;

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
    }
}

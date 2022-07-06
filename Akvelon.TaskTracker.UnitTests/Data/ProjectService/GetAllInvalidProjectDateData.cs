using Akvelon.TaskTracker.Repository.Entities;
using Bogus;

namespace Akvelon.TaskTracker.UnitTests.Data.ProjectService
{
    public class GetAllInvalidProjectDateData : TheoryData<DateTime?, DateTime?, string, string, string, ProjectPriority?>
    {
        public GetAllInvalidProjectDateData()
        {
            var faker = new Faker();

            var endProject = DateTime.UtcNow;
            var startProject = DateTime.UtcNow.AddDays(1);

            Add(startProject, endProject, faker.Random.String(), faker.Random.String(), faker.Random.String(), ProjectPriority.Medium);
        }
    }
}

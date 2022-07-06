using Akvelon.TaskTracker.Repository.Entities;
using Bogus;

namespace Akvelon.TaskTracker.UnitTests.Data.ProjectService
{
    //This is for faking the data for invalid test
    public class GetAllInvalidProjectDateData : TheoryData<DateTime?, DateTime?, string, string, string, ProjectPriority?>
    {
        public GetAllInvalidProjectDateData()
        {
            
            var faker = new Faker();

            //Invalid data on purpose to induce an exception
            var endProject = DateTime.UtcNow;
            var startProject = DateTime.UtcNow.AddDays(1);

            //Here faker is generating random data
            Add(startProject, endProject, faker.Random.String(), faker.Random.String(), faker.Random.String(), ProjectPriority.Medium);
        }
    }
}

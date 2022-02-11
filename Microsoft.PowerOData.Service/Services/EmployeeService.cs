using Microsoft.PowerOData.Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.PowerOData.Service
{
    public class EmployeeService : IRepoService<EmployeeModel>
    {
        public async Task<IList<EmployeeModel>> GetData() => await CreateData();

        private async Task<List<EmployeeModel>> CreateData()
        {
            List<EmployeeModel> empModels = new List<EmployeeModel>(); 
            
            await new TaskFactory().StartNew(() =>
            {

                empModels.Add(new EmployeeModel { Id = 1, Name = "Thor", Role = "Developer", City = "Asgard"});
                empModels.Add(new EmployeeModel { Id = 2, Name = "Steve", Role = "Architect", City = "Houston"});
                empModels.Add(new EmployeeModel { Id = 3, Name = "Clint", Role = "Developer", City = "Dallas"});
                empModels.Add(new EmployeeModel { Id = 4, Name = "Bruce", Role = "PM", City = "Austin"});
                empModels.Add(new EmployeeModel { Id = 5, Name = "TChalla", Role = "Architect", City = "Corpus Christie"});
                empModels.Add(new EmployeeModel { Id = 6, Name = "Natasha", Role = "DBA", City = "El Paso"});
                empModels.Add(new EmployeeModel { Id = 7, Name = "Carol", Role = "Specialist", City = "Baton Rouge"});
                empModels.Add(new EmployeeModel { Id = 8, Name = "Bucky", Role = "QA", City = "New Orleans"});
                empModels.Add(new EmployeeModel { Id = 9, Name = "Sam", Role = "DBA", City = "Lafayette"});
                empModels.Add(new EmployeeModel { Id = 10, Name = "Groot", Role = "Business Analyst", City = "New Iberia"});
                empModels.Add(new EmployeeModel { Id = 11, Name = "Rocket", Role = "QA", City = "Kansas City"});
                empModels.Add(new EmployeeModel { Id = 12, Name = "Peter", Role = "Business Analyst", City = "San Francisco"});
                empModels.Add(new EmployeeModel { Id = 13, Name = "Gamora", Role = "Developer", City = "Anaheim"});
                empModels.Add(new EmployeeModel { Id = 14, Name = "Nebula", Role = "Architect", City = "New York"});
                empModels.Add(new EmployeeModel { Id = 15, Name = "Drax", Role = "Manager", City = "Chicago"});
            });
            return empModels;
        }

        public  IQueryable<EmployeeModel> GetDataAsQueryable()
        {
            return (CreateData().Result).AsQueryable();
        }
    }
}
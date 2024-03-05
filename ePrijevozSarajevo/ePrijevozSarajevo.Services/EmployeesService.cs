using ePrijevozSarajevo.Model;

namespace ePrijevozSarajevo.Services
{
    public class EmployeesService : IEmployeesService
    {
        public List<Employees> EmployeesList = new List<Employees>()
        { 
            new Employees()
            {
                EmployeeId = 1,
                FirstName="Ime",
                LastName="Prezime",
                Email="ime.prezime@mail.com",
                DateOfBirth=DateTime.Now,
                PhoneNumber="033222555",
                Address="Neka 1"
            }
        };
        public List<Employees> GetEmployeesList()
        {
            return EmployeesList;
        }
    }
}

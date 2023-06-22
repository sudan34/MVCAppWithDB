using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Db.DbOperations
{
    public class EmployeeRepository
    {
        public int AddEmployee(EmployeeModel model) 
        {
            using (var context = new EmpolyeeDBEntities())
            {
                Employee emp = new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Code = model.Code,
                   
                };
                if (model.Address != null)
                {
                    emp.Address = new Address()
                    {
                        Details = model.Address.Details,
                        Country = model.Address.Country,
                        State = model.Address.State
                    };
                }
                context.Employee.Add(emp);
                context.SaveChanges();

                return emp.Id;
            }
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            using (var context = new EmpolyeeDBEntities())
            {
                var result = context.Employee.Select(x => new EmployeeModel()
                {
                    AddressId = x.AddressId,
                    Code = x.Code,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Address = new AddressModel()
                    {
                        Details= x.Address.Details,
                        Country = x.Address.Country,
                        State = x.Address.State
                    }

                }).ToList();

                return result;
            }   
        }
    }
}

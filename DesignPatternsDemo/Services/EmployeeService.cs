using DesignPatternsDemo.Repository;
using DesignPatternsDemo.UnitOfWork;
using System.Collections.Generic;

namespace DesignPatternsDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly UnitOfWork<EmployeeDBEntities> unitOfWork;
        private readonly GenericRepository<Employee> repository;
        public EmployeeService()
        {
            unitOfWork = new UnitOfWork<EmployeeDBEntities>();
            repository = new GenericRepository<Employee>(unitOfWork);
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return repository.GetAll();
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
            unitOfWork.CreateTransaction();
            repository.Insert(employee);
            unitOfWork.Save();
            //Do Some Other Task with the Database
            //If everything is working then commit the transaction else rollback the transaction
            unitOfWork.Commit();
            }
            catch (System.Exception)
            {
                unitOfWork.Rollback();
            }
        }

        public Employee GetByEmployeeID(int employeeID)
        {
            return repository.GetById(employeeID);
        }

        public void EditEmployee(Employee employee)
        {
            repository.Update(employee);
            unitOfWork.Save();
        }

        public void DeleteEmployee(int employeeID)
        {
            Employee model = GetByEmployeeID(employeeID);
            repository.Delete(model);
            unitOfWork.Save();
        }
    }
}
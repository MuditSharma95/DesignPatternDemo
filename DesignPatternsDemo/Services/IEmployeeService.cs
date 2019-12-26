using System.Collections.Generic;

namespace DesignPatternsDemo.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployee();
        void AddEmployee(Employee employee);
        Employee GetByEmployeeID(int employeeID);
        void EditEmployee(Employee employee);
        void DeleteEmployee(int employeeID);
    }
}
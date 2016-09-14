using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EYPDataService.Entities;
using System.Data.Objects;

namespace EYPDataService.DataAccess
{
    public class EmployeeDataAccess
    {
        public List<Employee> GetEmployeesByProjectName(string projectName)
        {
            EYPEntities entity = new EYPEntities();
            var result = entity.GetEmployeesByProject(projectName);

            List<GetEmployeesByProject_Result> resultList = result.ToList();

            if (resultList.Count > 0)
            {
                List<Employee> employees = (from e in resultList
                                            select new Employee()
                                            {
                                                EmpId = e.Id,
                                                Name = e.Name,
                                                Email = e.Email
                                            }).ToList();
                
                return employees;
            }
            else
            {
                return null;
            }
        }

        public Employee GetEmployeeDetailsByEmpId(string employeeId)
        {
            EYPEntities entity = new EYPEntities();
            ObjectResult<GetEmployeeByEmpId_Result> result = entity.GetEmployeeByEmpId(employeeId);

            List<GetEmployeeByEmpId_Result> resultList = result.ToList();
            if (resultList.Count > 0)
            {
                GetEmployeeByEmpId_Result data = resultList.First();

                Employee employee = new Employee()
                {
                    EmpId = data.Id,
                    Name = data.Name,
                    ProjectName = data.Project,
                    ManagerId = data.ManagerId,
                    ManagerName = data.ManagerName,
                    Email = data.Email,
                    IsManager = data.IsManager
                };

                return employee;
            }
            else
            {
                return null;
            }
        }

        public List<Employee> GetSubordinateListByManagerId(string managerId)
        {
            EYPEntities entity = new EYPEntities();
            var result = entity.GetSubordinateListByManagerId(managerId);
            List<GetSubordinateListByManagerId_Result> resultSet = result.ToList();

            if (resultSet.Count > 0)
            {
                List<Employee> employeeList = (from e in resultSet
                                               select new Employee()
                                               {
                                                   EmpId = e.Id,
                                                   Name = e.Name,
                                                   ProjectName = e.Project,
                                                   ManagerId = e.ManagerId,
                                                   Email = e.Email
                                               }).ToList();

                return employeeList;
            }
            else
            {
                return null;
            }
        }

        public void InsertEmployee(Employee employee)
        {
            EYPEntities entity = new EYPEntities();
            entity.InsertEmployee(employee.EmpId, employee.Name, employee.ProjectName, employee.ManagerId, employee.Email, employee.IsManager);
        }
    }
}
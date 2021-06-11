using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Labo6
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RestService : IRestService
    {
        /*
         * Console.WriteLine("Daria Hornik, 246700");
         * Console.WriteLine("Kamil Graczyk, 246994");
         * Console.WriteLine(DateTime.Now);
         * Console.WriteLine(Environment.MachineName + "\n");
         */

        private static List<Employee> EmployeeList = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                JobTitle = "Pracownik",
                VacationHours = 32
            },
            new Employee()
            {
                Id = 2,
                FirstName = "Anna",
                LastName = "Kowalska",
                JobTitle = "Manager",
                VacationHours = 40
            },
            new Employee()
            {
                Id = 3,
                FirstName = "Michał",
                LastName = "Nowicki",
                JobTitle = "Kierownik",
                VacationHours = 50
            },
        };

        public List<Employee> getAllXml()
        {
            return EmployeeList;
        }

        public Employee getByIdXml(string Id)
        {
            getAllXml();
            int intId = int.Parse(Id);
            int idx = EmployeeList.FindIndex(b => b.Id == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found",
                HttpStatusCode.NotFound);
            return EmployeeList.ElementAt(idx);
        }

        public string addXml(Employee item)
        {
            getAllXml();
            if (item == null)
                throw new WebFaultException<string>("400: BadRequest",
                HttpStatusCode.BadRequest);
            int idx = EmployeeList.FindIndex(b => b.Id == item.Id);
            if (idx == -1)
            {
                EmployeeList.Add(item);
                return "Added item with ID=" + item.Id;
            }
            else
                throw new WebFaultException<string>("409: Conflict",
                HttpStatusCode.Conflict);
        }

        public string updateXml(Employee item)
        {
            getAllXml();
            if (item == null)
                throw new WebFaultException<string>("400: BadRequest",
                HttpStatusCode.BadRequest);
            var employee = EmployeeList.FirstOrDefault(b => b.Id == item.Id);
            if (employee != null)
            {
                employee.FirstName = item.FirstName;
                employee.LastName = item.LastName;
                employee.JobTitle = item.JobTitle;
                employee.VacationHours = item.VacationHours;

                return "Updated item with ID=" + item.Id;
            }
            else
                throw new WebFaultException<string>("409: Conflict",
                HttpStatusCode.Conflict);
        }

        public string deleteXml(string Id)
        {
            getAllXml();
            int intId = int.Parse(Id);
            int idx = EmployeeList.FindIndex(b => b.Id == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found",
                HttpStatusCode.NotFound);
            EmployeeList.RemoveAt(idx);
            return "Deleted item with ID= " + Id.ToString();
        }

        public List<Employee> getAllJson()
        {
            return EmployeeList;
        }

        public Employee getByIdJson(string Id)
        {
            getAllXml();
            int intId = int.Parse(Id);
            int idx = EmployeeList.FindIndex(b => b.Id == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found",
                HttpStatusCode.NotFound);
            return EmployeeList.ElementAt(idx);
        }

        public string addJson(Employee item)
        {
            getAllXml();
            if (item == null)
                throw new WebFaultException<string>("400: BadRequest",
                HttpStatusCode.BadRequest);
            int idx = EmployeeList.FindIndex(b => b.Id == item.Id);
            if (idx == -1)
            {
                EmployeeList.Add(item);
                return "Added item with ID=" + item.Id;
            }
            else
                throw new WebFaultException<string>("409: Conflict",
                HttpStatusCode.Conflict);
        }

        public string deleteJson(string Id)
        {
            getAllXml();
            int intId = int.Parse(Id);
            int idx = EmployeeList.FindIndex(b => b.Id == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found",
                HttpStatusCode.NotFound);
            EmployeeList.RemoveAt(idx);
            return "Deleted item with ID= " + Id.ToString();
        }

        public string updateJson(Employee item)
        {
            getAllXml();
            if (item == null)
                throw new WebFaultException<string>("400: BadRequest",
                HttpStatusCode.BadRequest);
            var employee = EmployeeList.FirstOrDefault(b => b.Id == item.Id);
            if (employee != null)
            {
                employee.FirstName = item.FirstName;
                employee.LastName = item.LastName;
                employee.JobTitle = item.JobTitle;
                employee.VacationHours = item.VacationHours;
                return "Updated item with ID=" + item.Id;
            }
            else
                throw new WebFaultException<string>("409: Conflict",
                HttpStatusCode.Conflict);
        }
    }
}

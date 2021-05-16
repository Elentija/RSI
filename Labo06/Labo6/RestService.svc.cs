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

        private static List<Employee> EmployeeList = new List<Employee>();

        public List<Employee> getAllXml()
        {
            EmployeeList = new List<Employee>();
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=DESKTOP-IN8O3LQ;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, output = "";
            sql = @"SELECT BusinessEntityID, FirstName, LastName, JobTitle, VacationHours 
                    FROM AdventureWorks2019.dbo.EmployeeDB ORDER BY BusinessEntityID";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Employee newEmp = new Employee();
                newEmp.Id = (int)dataReader.GetValue(0);
                newEmp.FirstName = (string)dataReader.GetValue(1);
                newEmp.LastName = (string)dataReader.GetValue(2);
                newEmp.JobTitle = (string)dataReader.GetValue(3);
                newEmp.VacationHours = (Int16)dataReader.GetValue(4);
                EmployeeList.Add(newEmp);
            }
            cnn.Close();
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
                string connetionString;
                SqlConnection cnn;
                connetionString = @"Data Source=DESKTOP-IN8O3LQ;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                cnn = new SqlConnection(connetionString);
                cnn.Open();

                SqlCommand command;
                SqlDataReader dataReader;
                String sql, output = "";
                sql = @"INSERT INTO AdventureWorks2019.dbo.EmployeeDB
                        VALUES(" + item.Id + ",'" + item.FirstName + "','" + item.LastName + "','" + item.JobTitle + "'," + item.VacationHours + ")";
                command = new SqlCommand(sql, cnn);
                command.ExecuteNonQuery();
                cnn.Close();
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
            int idx = EmployeeList.FindIndex(b => b.Id == item.Id);
            if (idx != -1)
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = @"Data Source=DESKTOP-IN8O3LQ;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                cnn = new SqlConnection(connetionString);
                cnn.Open();

                SqlCommand command;
                SqlDataReader dataReader;
                String sql, output = "";
                sql = @"UPDATE AdventureWorks2019.dbo.EmployeeDB
                        SET FirstName = '" + item.FirstName + "', LastName = '" + item.LastName + "', JobTitle = '" + item.JobTitle + "', VacationHours = " + item.VacationHours +
                        "WHERE BusinessEntityID = " + item.Id + ";";
                command = new SqlCommand(sql, cnn);
                command.ExecuteNonQuery();
                cnn.Close();
                EmployeeList.Add(item);
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
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=DESKTOP-IN8O3LQ;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, output = "";
            sql = @"DELETE FROM AdventureWorks2019.dbo.EmployeeDB 
                    WHERE BusinessEntityID=" + Id;
            command = new SqlCommand(sql, cnn);
            command.ExecuteNonQuery();
            cnn.Close();
            EmployeeList.RemoveAt(idx);
            return "Deleted item with ID= " + Id.ToString();
        }




        public List<Employee> getAllJson()
        {
            EmployeeList = new List<Employee>();
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=DESKTOP-IN8O3LQ;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, output = "";
            sql = @"SELECT BusinessEntityID, FirstName, LastName, JobTitle, VacationHours 
                    FROM AdventureWorks2019.dbo.EmployeeDB ORDER BY BusinessEntityID";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Employee newEmp = new Employee();
                newEmp.Id = (int)dataReader.GetValue(0);
                newEmp.FirstName = (string)dataReader.GetValue(1);
                newEmp.LastName = (string)dataReader.GetValue(2);
                newEmp.JobTitle = (string)dataReader.GetValue(3);
                newEmp.VacationHours = (Int16)dataReader.GetValue(4);
                EmployeeList.Add(newEmp);
            }
            cnn.Close();
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
                string connetionString;
                SqlConnection cnn;
                connetionString = @"Data Source=DESKTOP-IN8O3LQ;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                cnn = new SqlConnection(connetionString);
                cnn.Open();

                SqlCommand command;
                SqlDataReader dataReader;
                String sql, output = "";
                sql = @"INSERT INTO AdventureWorks2019.dbo.EmployeeDB
                        VALUES(" + item.Id + ",'" + item.FirstName + "','" + item.LastName + "','" + item.JobTitle + "'," + item.VacationHours + ")";
                command = new SqlCommand(sql, cnn);
                command.ExecuteNonQuery();
                cnn.Close();
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
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=DESKTOP-IN8O3LQ;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, output = "";
            sql = @"DELETE FROM AdventureWorks2019.dbo.EmployeeDB 
                    WHERE BusinessEntityID=" + Id;
            command = new SqlCommand(sql, cnn);
            command.ExecuteNonQuery();
            cnn.Close();
            EmployeeList.RemoveAt(idx);
            return "Deleted item with ID= " + Id.ToString();
        }

        public string updateJson(Employee item)
        {
            getAllXml();
            if (item == null)
                throw new WebFaultException<string>("400: BadRequest",
                HttpStatusCode.BadRequest);
            int idx = EmployeeList.FindIndex(b => b.Id == item.Id);
            if (idx != -1)
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = @"Data Source=DESKTOP-IN8O3LQ;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                cnn = new SqlConnection(connetionString);
                cnn.Open();

                SqlCommand command;
                SqlDataReader dataReader;
                String sql, output = "";
                sql = @"UPDATE AdventureWorks2019.dbo.EmployeeDB
                        SET FirstName = '" + item.FirstName + "', LastName = '" + item.LastName + "', JobTitle = '" + item.JobTitle + "', VacationHours = " + item.VacationHours +
                        "WHERE BusinessEntityID = " + item.Id + ";";
                command = new SqlCommand(sql, cnn);
                command.ExecuteNonQuery();
                cnn.Close();
                EmployeeList.Add(item);
                return "Updated item with ID=" + item.Id;
            }
            else
                throw new WebFaultException<string>("409: Conflict",
                HttpStatusCode.Conflict);
        }
    }
}

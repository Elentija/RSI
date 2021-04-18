using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceContract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SpaceX : ISpaceX
    {
       
        public async Task<object> SaleBeetween2013_2014()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=ELENTIYA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, output = "";
            sql = @"SELECT  TOP(100) OrderDate, Person.FirstName, Person.LastName, SubTotal
                FROM AdventureWorks2019.Sales.SalesOrderHeader
                JOIN AdventureWorks2019.Sales.Customer ON SalesOrderHeader.CustomerID = Customer.CustomerID
                JOIN AdventureWorks2019.Person.Person ON Customer.PersonID = Person.BusinessEntityID
                WHERE OrderDate > '10.10.2013' AND OrderDate< '10.10.2014'";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while(dataReader.Read())
            {
                output += dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2) + " - " + dataReader.GetValue(3) +" zł" + "\n";
            }
            Console.WriteLine("Metoda 1");
            Console.WriteLine(output);
            cnn.Close();
            return output;
        }

        public async Task<object> SumSaleInDay(int d, int m, int y)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=ELENTIYA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, output = "";
            sql = @"SELECT DAY(OrderDate), MONTH(OrderDate), YEAR(OrderDate), SUM(SubTotal)
                FROM AdventureWorks2019.Sales.SalesOrderHeader
                WHERE DAY(OrderDate) = "+d.ToString() + " AND MONTH(OrderDate) = " + m.ToString() + " AND YEAR(OrderDate) =" + y.ToString() +
                " GROUP BY DAY(OrderDate), MONTH(OrderDate), YEAR(OrderDate)";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                output += "Dzień" +dataReader.GetValue(0) + " - Miesiąc: " + dataReader.GetValue(1) + " - Rok: " + dataReader.GetValue(2) + " - Wartość: " + dataReader.GetValue(3) + " zł" + "\n";
            }
            Console.WriteLine("Metoda 2");
            cnn.Close();
            return output;
        }

        public async Task<object> NumberOfSoldProduct(string name, string lastname)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=ELENTIYA;Integrated Security=True;Connect Timeout=1000;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, output = "";
            sql = @"SELECT TOP(10) Product.Name, COUNT(Product.ProductID) 
                FROM AdventureWorks2019.Person.Person
                JOIN AdventureWorks2019.HumanResources.Employee ON Employee.BusinessEntityID = Person.BusinessEntityID
                JOIN AdventureWorks2019.Sales.SalesPerson ON SalesPerson.BusinessEntityID = Employee.BusinessEntityID
                JOIN AdventureWorks2019.Sales.SalesOrderHeader ON SalesOrderHeader.SalesPersonID = SalesPerson.BusinessEntityID
                JOIN AdventureWorks2019.Sales.SalesOrderDetail ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID
                JOIN AdventureWorks2019.Production.Product ON Product.ProductID = SalesOrderDetail.ProductID 
                WHERE Person.LastName ='" + lastname.ToString() + "' AND Person.FirstName = '" + name.ToString() + "' GROUP BY Product.Name";

            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                output += dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " sztuk" + "\n";
            }
            Console.WriteLine("Metoda 3");
            Console.WriteLine(output);
            cnn.Close();
            return output;
        }
    }
}

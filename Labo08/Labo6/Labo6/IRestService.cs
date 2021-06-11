using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Labo6
{
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/employee",
        ResponseFormat = WebMessageFormat.Xml)]
        List<Employee> getAllXml();

        [OperationContract]
        [WebGet(UriTemplate = "/employee/{id}",
        ResponseFormat = WebMessageFormat.Xml)]
        Employee getByIdXml(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/employee",
        Method = "POST",
        RequestFormat = WebMessageFormat.Xml)]
        string addXml(Employee item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/employee/{id}/delete", Method = "DELETE",
        ResponseFormat = WebMessageFormat.Xml)]
        string deleteXml(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/employee/modify",
        Method = "POST",
        RequestFormat = WebMessageFormat.Xml)]
        string updateXml(Employee item);

        [OperationContract]
        [WebGet(UriTemplate = "/json/employee",
        ResponseFormat = WebMessageFormat.Json)]
        List<Employee> getAllJson();

        [OperationContract]
        [WebGet(UriTemplate = "/json/employee/{id}",
        ResponseFormat = WebMessageFormat.Json)]
        Employee getByIdJson(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/employee",
        Method = "POST",
        RequestFormat = WebMessageFormat.Json)]
        string addJson(Employee item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/employee/{id}/delete", Method = "DELETE",
        ResponseFormat = WebMessageFormat.Json)]
        string deleteJson(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "json/employee/modify",
        Method = "POST",
        RequestFormat = WebMessageFormat.Json)]
        string updateJson(Employee item);
    }

    [DataContract]
    public class Employee
    {
        
        [DataMember(Order = 0)]
        public int Id { get; set; }
        [DataMember(Order = 1)]
        public string FirstName { get; set; }
        [DataMember(Order = 2)]
        public string LastName { get; set; }
        [DataMember(Order = 3)]
        public string JobTitle { get; set; }
        [DataMember(Order = 4)]
        public int VacationHours { get; set; }
    }
}

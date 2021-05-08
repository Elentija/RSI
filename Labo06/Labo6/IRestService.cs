using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Labo6
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IRestService” w kodzie i pliku konfiguracji.
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/employee")]
        List<Employee> getAllXml();
        [OperationContract]
        [WebGet(UriTemplate = "/employee/{id}",
        ResponseFormat = WebMessageFormat.Json)]
        Employee getByIdXml(string Id);
        [OperationContract]
        [WebInvoke(UriTemplate = "/employee",
        Method = "POST",
        RequestFormat = WebMessageFormat.Json)]
        string addXml(Employee item);
        [OperationContract]
        [WebInvoke(UriTemplate = "/employee/{id}/delete", Method = "DELETE")]
        string deleteXml(string Id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/employee")]
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
        [WebInvoke(UriTemplate = "/json/employee/{id}/delete", Method = "DELETE")]
        string deleteJson(string Id);
    }



    // Użyj kontraktu danych, jak pokazano w poniższym przykładzie, aby dodać typy złożone do operacji usługi.
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

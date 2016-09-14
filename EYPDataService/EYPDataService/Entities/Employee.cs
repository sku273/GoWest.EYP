using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace EYPDataService.Entities
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public string EmpId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ProjectName { get; set; }
        [DataMember]
        public string ManagerId { get; set; }
        [DataMember]
        public string ManagerName { get; set; }
        [DataMember]
        public bool IsManager { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public Feedback EmployeeFeedback { get; set; }
    }
}
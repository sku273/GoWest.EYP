using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EYPDataService.Entities
{
    [DataContract]
    public class ActionItem
    {
        [DataMember]
        public string ActionItemDesc { get; set; }
        [DataMember]
        public Employee Owner { get; set; }
        [DataMember]
        public DateTime? DueDate { get; set; }
        [DataMember]
        public Status Status { get; set; }
        [DataMember]
        public string Remarks { get; set; }
    }
}
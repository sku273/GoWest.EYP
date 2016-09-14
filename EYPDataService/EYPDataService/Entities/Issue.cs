using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EYPDataService.Entities
{
    [DataContract]
    public class Issue
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string IssueDesc { get; set; }
        [DataMember]
        public string ActionItem { get; set; }
        [DataMember]
        public Employee Owner { get; set; }
        [DataMember]
        public DateTime? DueDate { get; set; }
        [DataMember]
        public Status Status { get; set; }
        [DataMember]
        public DateTime? ConversationDate { get; set; }
    }
}
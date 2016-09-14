using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EYPDataService.Entities
{
    [DataContract]
    public class TrainingPlan
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string TrainingArea { get; set; }
        [DataMember]
        public string TrainingProgram { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string Timeframe { get; set; }
        [DataMember]
        public string ClosedMonth { get; set; }
        [DataMember]
        public Status Status { get; set; }
        [DataMember]
        public DateTime ConversationDate { get; set; }
    }
}
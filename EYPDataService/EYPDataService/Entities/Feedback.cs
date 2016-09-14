using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EYPDataService.Entities
{
    [DataContract]
    public class Feedback
    {
        [DataMember]
        public List<FeedbackQuesAns> FeedbackQuesAns { get; set; }
        [DataMember]
        public List<TrainingPlan> TrainingPlans { get; set; }
        //[DataMember]
        //public List<ActionItem> ActionItems { get; set; }
        [DataMember]
        public List<Issue> Issues { get; set; }
        [DataMember]
        public List<EmployeeDNA> EmployeeDNA { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EYPDataService.Entities
{
    /// <summary>
    /// FeedbackQuestions will cater to all the question and answer type feedbacks 
    /// </summary>
    [DataContract]
    public class FeedbackQuesAns
    {
        [DataMember]
        public Question Question { get; set; }
        [DataMember]
        public string Answer { get; set; }
        [DataMember]
        public int? RatingScale { get; set; }
        [DataMember]
        public DateTime? ConversationDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EYPDataService.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<string> DefaultValues { get; set; }
    }
}
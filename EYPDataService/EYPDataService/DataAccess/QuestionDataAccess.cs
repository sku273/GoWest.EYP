using EYPDataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EYPDataService.DataAccess
{
    public class QuestionDataAccess
    {
        public void InsertQuestion(Question question)
        {
            EYPEntities entity = new EYPEntities();
            entity.InsertQuestion(question.Name, Enum.GetName(typeof(QuestionType), question.QuestionType), question.DefaultValues != null && question.DefaultValues.Count > 0 ? question.DefaultValues.Aggregate((x, y) => x + "," + y) : null);
        }

        public List<Question> GetQuestionsByQuestionType(QuestionType questionType)
        {
            EYPEntities entity = new EYPEntities();
            var result = entity.GetQuestionsByQuestionType(questionType.ToString());
            var resultSet = result.ToList();

            if (resultSet.Count > 0)
            {
                List<Question> questions = (from r in resultSet
                                            select new Question()
                                            {
                                                Id = r.Id,
                                                Name = r.Question,
                                                QuestionType = (QuestionType)Enum.Parse(typeof(QuestionType), r.QuestionType),
                                                DefaultValues = r.DefaultAnswerValues != null ? r.DefaultAnswerValues.Split(',').ToList() : null
                                            }).ToList();
                return questions;
            }
            else
            {
                return null;
            }
        }
    }
}
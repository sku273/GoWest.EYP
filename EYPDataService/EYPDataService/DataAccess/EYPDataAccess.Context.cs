﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EYPDataService.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class EYPEntities : DbContext
    {
        public EYPEntities()
            : base("name=EYPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<GetEmployeeByEmpId_Result> GetEmployeeByEmpId(string empId)
        {
            var empIdParameter = empId != null ?
                new ObjectParameter("EmpId", empId) :
                new ObjectParameter("EmpId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetEmployeeByEmpId_Result>("GetEmployeeByEmpId", empIdParameter);
        }
    
        public virtual int InsertEmployee(string empId, string name, string projectName, string managerId, string email, Nullable<bool> isManager)
        {
            var empIdParameter = empId != null ?
                new ObjectParameter("EmpId", empId) :
                new ObjectParameter("EmpId", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var projectNameParameter = projectName != null ?
                new ObjectParameter("ProjectName", projectName) :
                new ObjectParameter("ProjectName", typeof(string));
    
            var managerIdParameter = managerId != null ?
                new ObjectParameter("ManagerId", managerId) :
                new ObjectParameter("ManagerId", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var isManagerParameter = isManager.HasValue ?
                new ObjectParameter("IsManager", isManager) :
                new ObjectParameter("IsManager", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertEmployee", empIdParameter, nameParameter, projectNameParameter, managerIdParameter, emailParameter, isManagerParameter);
        }
    
        public virtual int InsertQuestion(string question, string questionType, string defaultAnswerValues)
        {
            var questionParameter = question != null ?
                new ObjectParameter("Question", question) :
                new ObjectParameter("Question", typeof(string));
    
            var questionTypeParameter = questionType != null ?
                new ObjectParameter("QuestionType", questionType) :
                new ObjectParameter("QuestionType", typeof(string));
    
            var defaultAnswerValuesParameter = defaultAnswerValues != null ?
                new ObjectParameter("DefaultAnswerValues", defaultAnswerValues) :
                new ObjectParameter("DefaultAnswerValues", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertQuestion", questionParameter, questionTypeParameter, defaultAnswerValuesParameter);
        }
    
        public virtual ObjectResult<GetQuestionsByQuestionType_Result> GetQuestionsByQuestionType(string questionType)
        {
            var questionTypeParameter = questionType != null ?
                new ObjectParameter("QuestionType", questionType) :
                new ObjectParameter("QuestionType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetQuestionsByQuestionType_Result>("GetQuestionsByQuestionType", questionTypeParameter);
        }
    
        public virtual ObjectResult<GetSubordinateListByManagerId_Result> GetSubordinateListByManagerId(string managerId)
        {
            var managerIdParameter = managerId != null ?
                new ObjectParameter("ManagerId", managerId) :
                new ObjectParameter("ManagerId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSubordinateListByManagerId_Result>("GetSubordinateListByManagerId", managerIdParameter);
        }
    
        public virtual ObjectResult<EmployeeFeedback_Result> GetEmployeeFeedbackByEmpId(string empId)
        {
            var empIdParameter = empId != null ?
                new ObjectParameter("EmpId", empId) :
                new ObjectParameter("EmpId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmployeeFeedback_Result>("GetEmployeeFeedbackByEmpId", empIdParameter);
        }
    
        public virtual ObjectResult<GetFeedbackQuesAnsHistory_Result> GetFeedbackQuesAnsHistory(string empId, Nullable<int> questionId)
        {
            var empIdParameter = empId != null ?
                new ObjectParameter("empId", empId) :
                new ObjectParameter("empId", typeof(string));
    
            var questionIdParameter = questionId.HasValue ?
                new ObjectParameter("questionId", questionId) :
                new ObjectParameter("questionId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFeedbackQuesAnsHistory_Result>("GetFeedbackQuesAnsHistory", empIdParameter, questionIdParameter);
        }
    
        public virtual ObjectResult<GetIssueHistory_Result> GetIssueHistory(Nullable<int> issueId)
        {
            var issueIdParameter = issueId.HasValue ?
                new ObjectParameter("IssueId", issueId) :
                new ObjectParameter("IssueId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetIssueHistory_Result>("GetIssueHistory", issueIdParameter);
        }
    
        public virtual ObjectResult<GetTrainingPlanHistory_Result> GetTrainingPlanHistory(Nullable<int> trainingPlanId)
        {
            var trainingPlanIdParameter = trainingPlanId.HasValue ?
                new ObjectParameter("TrainingPlanId", trainingPlanId) :
                new ObjectParameter("TrainingPlanId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTrainingPlanHistory_Result>("GetTrainingPlanHistory", trainingPlanIdParameter);
        }
    
        public virtual ObjectResult<GetEmployeesByProject_Result> GetEmployeesByProject(string projectName)
        {
            var projectNameParameter = projectName != null ?
                new ObjectParameter("projectName", projectName) :
                new ObjectParameter("projectName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetEmployeesByProject_Result>("GetEmployeesByProject", projectNameParameter);
        }
    }
}

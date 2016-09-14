using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EYPDataService.Entities;

namespace EYPDataService
{
    [ServiceContract]
    public interface IEYPDataService
    {
        [OperationContract]
        Employee GetEmployeeDetailsByEmpId(string employeeId);

        [OperationContract]
        void InsertEmployee(Employee employee);

        [OperationContract]
        void InsertQuestion(Question question);

        [OperationContract]
        [WebInvoke(Method = "POST", 
            ResponseFormat = WebMessageFormat.Json, 
            RequestFormat = WebMessageFormat.Json)]
        List<Question> GetQuestionsByQuestionType(QuestionType questionType);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        Employee GetEmployeeFeedback(string empId);//, string managerId);

        [OperationContract]
        void InsertEmployeeFeedback(Employee feedback);

        [OperationContract]
        List<Employee> GetSubordinateListByManagerId(string managerId);

        [OperationContract]
        void ImportDNASheet(string excelSheetPath);
        
        [OperationContract]
        void ImportEmployeeData(string excelSheetPath);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<FeedbackQuesAns> GetFeedbackQuesAnsHistory(string empId, int questionId);

        [OperationContract]
        List<Issue> GetIssueHistory(int issueId);

        [OperationContract]
        List<TrainingPlan> GetTrainingPlanHistory(int trainingPlanId);

        [OperationContract]
        List<Employee> GetEmployeesByProjectName(string projectName);
    }
}

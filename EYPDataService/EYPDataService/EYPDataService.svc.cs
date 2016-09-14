using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EYPDataService.Entities;
using EYPDataService.DataAccess;
using System.ServiceModel.Activation;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace EYPDataService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EYPDataService : IEYPDataService
    {
        string excelConnStr = System.Configuration.ConfigurationManager.AppSettings["ExcelSheetConnectionString"];

        public Employee GetEmployeeDetailsByEmpId(string employeeId)
        {
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();
            Employee employee = dataAccess.GetEmployeeDetailsByEmpId(employeeId);
            if (employee == null)
            {
                ThrowHttpException("Employee Not found in system. Please upload employee details and retry");
            }

            return employee;
        }

        public void InsertEmployee(Employee employee)
        {
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();
            dataAccess.InsertEmployee(employee);
        }

        public void InsertQuestion(Question question)
        {
            QuestionDataAccess dataAccess = new QuestionDataAccess();
            dataAccess.InsertQuestion(question);
        }

        public List<Question> GetQuestionsByQuestionType(QuestionType questionType)
        {
            QuestionDataAccess dataAccess = new QuestionDataAccess();
            return dataAccess.GetQuestionsByQuestionType(questionType);
        }

        public Employee GetEmployeeFeedback(string empId)
        {
            EmployeeFeedbackDataAccess dataAccess = new EmployeeFeedbackDataAccess();
            Employee employee = dataAccess.GetEmployeeFeedback(empId);
            if (employee == null)
            {
                ThrowHttpException("Employee Not found in system. Please upload employee details and retry");
            }
            return employee;
        }

        public void InsertEmployeeFeedback(Employee feedback)
        {
            EmployeeFeedbackDataAccess dataAccess = new EmployeeFeedbackDataAccess();
            dataAccess.InsertEmployeeFeedback(feedback.EmpId, feedback.ManagerId, feedback.EmployeeFeedback);
            EmailHelper.SendEmail(feedback.EmployeeFeedback);
        }

        public List<Employee> GetSubordinateListByManagerId(string managerId)
        {
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();
            return dataAccess.GetSubordinateListByManagerId(managerId);
        }

        public void ImportDNASheet(string excelSheetPath)
        {
            DataTable table = new DataTable();
            string connStr = String.Format(excelConnStr, excelSheetPath);

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                OleDbCommand cmd = new OleDbCommand("Select * from [DNAExport$]", conn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(table);

                conn.Close();
            }

            if (table.Rows.Count > 0)
            {
                EmployeeFeedbackDataAccess dataAccess = new EmployeeFeedbackDataAccess();
                dataAccess.InsertDNASheetData(table);
            }
        }

        public void ImportEmployeeData(string excelSheetPath)
        {
            DataTable table = new DataTable();
            string connStr = String.Format(excelConnStr, excelSheetPath);

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                OleDbCommand cmd = new OleDbCommand("Select * from [EmployeeStaticData$]", conn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(table);

                conn.Close();
            }

            if (table.Rows.Count > 0)
            {
                EmployeeFeedbackDataAccess dataAccess = new EmployeeFeedbackDataAccess();
                dataAccess.InsertEmployeeData(table);
            }
        }

        public List<FeedbackQuesAns> GetFeedbackQuesAnsHistory(string empId, int questionId)
        {
            EmployeeFeedbackDataAccess dataAccess = new EmployeeFeedbackDataAccess();
            return dataAccess.GetFeedbackQuesAnsHistory(empId, questionId);
        }

        public List<Issue> GetIssueHistory(int issueId)
        {
            EmployeeFeedbackDataAccess dataAccess = new EmployeeFeedbackDataAccess();
            return dataAccess.GetIssueHistory(issueId);
        }

        public List<TrainingPlan> GetTrainingPlanHistory(int trainingPlanId)
        {
            EmployeeFeedbackDataAccess dataAccess = new EmployeeFeedbackDataAccess();
            return dataAccess.GetTrainingPlanHistory(trainingPlanId);
        }

        public List<Employee> GetEmployeesByProjectName(string projectName)
        {
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();
            return dataAccess.GetEmployeesByProjectName(projectName);
        }

        private void ThrowHttpException(string message)
        {
            Exception ex = new Exception(message);
            System.Web.HttpContext.Current.Response.Write(ex.Message);
            throw new Exception(ex.Message, ex.InnerException);
        }
    }
}

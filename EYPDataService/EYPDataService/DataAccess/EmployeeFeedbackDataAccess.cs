using EYPDataService.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using entities = EYPDataService.Entities;

namespace EYPDataService.DataAccess
{
    public class EmployeeFeedbackDataAccess
    {
        public void InsertEmployeeData(DataTable employeeData)
        {
            DataTable employeeDataTable = GetEmployeeDataTable();

            SqlParameter employeeDataParam = new SqlParameter("@employeeData", SqlDbType.Structured);
            employeeDataParam.Value = employeeData;
            employeeDataParam.TypeName = "EmployeeType";

            EYPEntities entity = new EYPEntities();
            entity.Database.ExecuteSqlCommand("Exec InsertEmployeesData @employeeData", employeeDataParam);
        }

        public void InsertDNASheetData(DataTable dnaSheetData)
        {
            DataTable dnaData = GetDNADataTable();
            EYPEntities entity = new EYPEntities();

            foreach (DataRow row in dnaSheetData.Rows)
            {
                if (row[0].ToString() != "0" && !string.IsNullOrEmpty(row[0].ToString()))
                {
                    for (int i = 1; i < dnaSheetData.Columns.Count; i++)
                    {
                        DataRow dnaDataRow = dnaData.NewRow();
                        dnaDataRow["EmpId"] = row[0];
                        dnaDataRow["Area"] = dnaSheetData.Columns[i].ColumnName;
                        dnaDataRow["Rating"] = row[i];
                        dnaData.Rows.Add(dnaDataRow);
                    }
                }
            }

            SqlParameter employeeDNADataParam = new SqlParameter("@employeeDNAData", SqlDbType.Structured);
            employeeDNADataParam.Value = dnaData;
            employeeDNADataParam.TypeName = "EmployeeDNAType";

            entity.Database.ExecuteSqlCommand("Exec InsertEmployeeDNA @employeeDNAData", employeeDNADataParam);
        }

        public void InsertEmployeeFeedback(string empId, string managerId, entities.Feedback feedback)
        {
            EYPEntities entity = new EYPEntities();

            //DataTable actionItem = GetActionItemDataTable();
            //foreach (var item in feedback.ActionItems)
            //{
            //    actionItem.Rows.Add(item.ActionItemDesc, item.Owner.Name, item.DueDate, item.Status, item.Remarks);
            //}
            //SqlParameter actionItemParam = new SqlParameter("@ActionItem", SqlDbType.Structured);
            //actionItemParam.Value = actionItem;
            //actionItemParam.TypeName = "ActionItemType";

            DataTable issue = GetIssueDataTable();
            foreach (var item in feedback.Issues)
            {
                issue.Rows.Add(item.Id, item.IssueDesc, item.ActionItem, item.Owner.EmpId, item.DueDate, item.Status);
            }
            SqlParameter issueParam = new SqlParameter("@Issue", SqlDbType.Structured);
            issueParam.Value = issue;
            issueParam.TypeName = "IssueType";

            DataTable feedbackQuesAns = GetEmployeeFeedbackQuesAnsDataTable();
            foreach (var item in feedback.FeedbackQuesAns)
            {
                if (!string.IsNullOrEmpty(item.Answer) || item.Question.QuestionType == entities.QuestionType.StabilityAnalysis)
                    feedbackQuesAns.Rows.Add(item.Question.Id, item.Answer, item.RatingScale);
            }
            SqlParameter feedbackQuesAnsParam = new SqlParameter("@FeedbackQuesAns", SqlDbType.Structured);
            feedbackQuesAnsParam.Value = feedbackQuesAns;
            feedbackQuesAnsParam.TypeName = "FeedbackQuesAnsType";

            DataTable trainingPlan = GetTrainingPlanDataTable();
            foreach (var item in feedback.TrainingPlans)
            {
                trainingPlan.Rows.Add(item.Id, item.TrainingArea, item.TrainingProgram, item.Remarks, item.Timeframe, item.ClosedMonth, item.Status);
            }
            SqlParameter trainingPlanParam = new SqlParameter("@TrainingPlan", SqlDbType.Structured);
            trainingPlanParam.Value = trainingPlan;
            trainingPlanParam.TypeName = "TrainingPlanType";

            SqlParameter employeeIdParam = new SqlParameter("@EmpId", SqlDbType.VarChar);
            employeeIdParam.Value = empId;

            SqlParameter managerIdParam = new SqlParameter("@ManagerId", SqlDbType.VarChar);
            managerIdParam.Value = managerId;

            //entity.Database.ExecuteSqlCommand("EXEC [InsertEmployeeFeeback] @EmpId, @ManagerId, @FeedbackQuesAns, @ActionItem, @Issue, @TrainingPlan",
            //    employeeIdParam, managerIdParam, feedbackQuesAnsParam, actionItemParam, issueParam, trainingPlanParam);
            entity.Database.ExecuteSqlCommand("EXEC [InsertEmployeeFeeback] @EmpId, @ManagerId, @FeedbackQuesAns, @Issue, @TrainingPlan",
                employeeIdParam, managerIdParam, feedbackQuesAnsParam, issueParam, trainingPlanParam);
        }

        public entities.Employee GetEmployeeFeedback(string employeeId)//, int managerId)
        {
            EYPEntities entity = new EYPEntities();
            var result = entity.GetEmployeeFeedbackByEmpId(employeeId);//, managerId);
            List<EmployeeFeedback_Result> employeeFeedbackResult = result.ToList();

            //var actionItemResultSet = result.GetNextResult<ActionItem_Result>();
            //List<ActionItem_Result> actionItemResult = actionItemResultSet.ToList();

            var issueResultSet = result.GetNextResult<Issue_Result>();
            List<Issue_Result> issueResult = issueResultSet.ToList();

            var trainingPlanResultSet = issueResultSet.GetNextResult<TrainingPlan_Result>();
            List<TrainingPlan_Result> trainingPlanResult = trainingPlanResultSet.ToList();

            var employeeDNAResultSet = trainingPlanResultSet.GetNextResult<EmployeeDNA_Result>();
            List<EmployeeDNA_Result> employeeDNAresult = employeeDNAResultSet.ToList();

            var employeeDetailsResultSet = employeeDNAResultSet.GetNextResult<EmployeeDetails_Result>();
            List<EmployeeDetails_Result> employeeDetailsResult = employeeDetailsResultSet.ToList();

            if (employeeDetailsResult.Count > 0)
            {
                entities.Employee feedback = new entities.Employee()
                {
                    EmpId = employeeDetailsResult.First().Id,
                    Name = employeeDetailsResult.First().Name,
                    ManagerId = employeeDetailsResult.First().ManagerId,
                    ManagerName = employeeDetailsResult.First().ManagerName,
                    ProjectName = employeeDetailsResult.First().Project,
                    Email = employeeDetailsResult.First().Email,
                    IsManager = employeeDetailsResult.First().IsManager,
                    EmployeeFeedback = new entities.Feedback()
                    {
                        FeedbackQuesAns = employeeFeedbackResult.Count > 0 ? (from e in employeeFeedbackResult
                                                                              select new entities.FeedbackQuesAns()
                                                                            {
                                                                                Question = new entities.Question() { Id = e.QuestionId, Name = e.Question, QuestionType = (QuestionType)Enum.Parse(typeof(QuestionType), e.QuestionType) },
                                                                                Answer = e.Answer,
                                                                                RatingScale = e.RatingScale,
                                                                                ConversationDate = e.CreatedDate
                                                                            }).ToList() : null,
                        //ActionItems = actionItemResult.Count > 0 ? (from a in actionItemResult
                        //                                            select new entities.ActionItem()
                        //                                            {
                        //                                                ActionItemDesc = a.ActionItemDesc,
                        //                                                DueDate = a.DueDate,
                        //                                                Owner = new entities.Employee() { Name = a.Owner },
                        //                                                Status = (entities.Status)Enum.Parse(typeof(entities.Status), a.Status),
                        //                                                Remarks = a.Remarks
                        //                                            }).ToList() : null,
                        Issues = issueResult.Count > 0 ? (from i in issueResult
                                                          select new entities.Issue()
                                                          {
                                                              Id = i.Id,
                                                              IssueDesc = i.IssueDesc,
                                                              ActionItem = i.ActionItem,
                                                              Owner = new entities.Employee() { EmpId = i.OwnerId, Name = i.OwnerName },
                                                              DueDate = i.DueDate,
                                                              Status = (entities.Status)Enum.Parse(typeof(entities.Status), i.Status),
                                                              ConversationDate = i.CreatedDate
                                                          }).ToList() : null,
                        TrainingPlans = trainingPlanResult.Count > 0 ? (from t in trainingPlanResult
                                                                        select new entities.TrainingPlan()
                                                                        {
                                                                            Id = t.Id,
                                                                            TrainingArea = t.TrainingArea,
                                                                            TrainingProgram = t.TrainingProgram,
                                                                            Timeframe = t.Timeframe,
                                                                            Remarks = t.Remarks,
                                                                            ClosedMonth = t.ClosedMonth,
                                                                            Status = (entities.Status)Enum.Parse(typeof(entities.Status), t.Status),
                                                                            ConversationDate = t.CreatedDate
                                                                        }).ToList() : null,
                        EmployeeDNA = employeeDNAresult.Count > 0 ? (from d in employeeDNAresult
                                                                     select new entities.EmployeeDNA()
                                                                     {
                                                                         Area = d.Area,
                                                                         Rating = d.Rating
                                                                     }).ToList() : null
                    }
                };
                return feedback;
            }
            else
            {
                return null;
            }
        }

        public List<FeedbackQuesAns> GetFeedbackQuesAnsHistory(string empId, int questionId)
        {
            EYPEntities entity = new EYPEntities();
            var data = entity.GetFeedbackQuesAnsHistory(empId, questionId).ToList();

            List<FeedbackQuesAns> feedbackQuesAns = (from f in data
                                                     select new FeedbackQuesAns
                                                     {
                                                         Question = new Question() { Id = f.QuestionId },
                                                         Answer = f.Answer,
                                                         RatingScale = f.RatingScale,
                                                         ConversationDate = f.CreatedDate
                                                     }).ToList();

            return feedbackQuesAns;
        }

        public List<Issue> GetIssueHistory(int issueId)
        {
            EYPEntities entity = new EYPEntities();
            var data = entity.GetIssueHistory(issueId).ToList();

            List<Issue> issues = (from i in data
                                  select new Issue
                                  {
                                      IssueDesc = i.IssueDesc,
                                      ActionItem = i.ActionItem,
                                      Status = (Status)Enum.Parse(typeof(Status), i.Status),
                                      Owner = new Employee() { Name = i.OwnerName },
                                      DueDate = i.DueDate,
                                      ConversationDate = i.CreatedDate
                                  }).ToList();

            return issues;
        }

        public List<TrainingPlan> GetTrainingPlanHistory(int trainingPlanId)
        {
            EYPEntities entity = new EYPEntities();
            var data = entity.GetTrainingPlanHistory(trainingPlanId).ToList();

            List<TrainingPlan> trainingPlanHistory = (from t in data
                                                      select new TrainingPlan
                                                      {
                                                          TrainingArea = t.TrainingArea,
                                                          TrainingProgram = t.TrainingProgram,
                                                          Timeframe = t.Timeframe,
                                                          Status = (Status)Enum.Parse(typeof(Status), t.Status),
                                                          Remarks = t.Remarks,
                                                          ConversationDate = t.CreatedDate,
                                                          ClosedMonth = t.ClosedMonth
                                                      }).ToList();

            return trainingPlanHistory;
        }

        private DataTable GetDNADataTable()
        {
            DataTable dnaData = new DataTable();

            dnaData.Columns.Add("EmpId", typeof(string));
            dnaData.Columns.Add("Area", typeof(string));
            dnaData.Columns.Add("Rating", typeof(string));

            return dnaData;
        }

        private DataTable GetEmployeeDataTable()
        {
            DataTable employeeTable = new DataTable();

            employeeTable.Columns.Add("Id", typeof(string));
            employeeTable.Columns.Add("Name", typeof(string));
            employeeTable.Columns.Add("Project", typeof(string));
            employeeTable.Columns.Add("ManagerId", typeof(string));
            employeeTable.Columns.Add("Email", typeof(string));
            employeeTable.Columns.Add("IsManager", typeof(bool));

            return employeeTable;
        }

        private DataTable GetEmployeeFeedbackQuesAnsDataTable()
        {
            DataTable employeeFeedBackQuesAns = new DataTable();

            employeeFeedBackQuesAns.Columns.Add("QuestionId", typeof(int));
            employeeFeedBackQuesAns.Columns.Add("Answer", typeof(string));
            employeeFeedBackQuesAns.Columns.Add("RatingScale", typeof(int));

            return employeeFeedBackQuesAns;
        }

        //private DataTable GetActionItemDataTable()
        //{
        //    DataTable actionItem = new DataTable();

        //    actionItem.Columns.Add("ActionItemDesc", typeof(string));
        //    actionItem.Columns.Add("Owner", typeof(string));
        //    actionItem.Columns.Add("DueDate", typeof(DateTime));
        //    actionItem.Columns.Add("Status", typeof(string));
        //    actionItem.Columns.Add("Remarks", typeof(string));

        //    return actionItem;
        //}

        private DataTable GetIssueDataTable()
        {
            DataTable issue = new DataTable();

            issue.Columns.Add("Id", typeof(int));
            issue.Columns.Add("IssueDesc", typeof(string));
            issue.Columns.Add("ActionItemDesc", typeof(string));
            issue.Columns.Add("OwnerId", typeof(string));
            issue.Columns.Add("DueDate", typeof(DateTime));
            issue.Columns.Add("Status", typeof(string));

            return issue;
        }

        private DataTable GetTrainingPlanDataTable()
        {
            DataTable trainingPlan = new DataTable();

            trainingPlan.Columns.Add("Id", typeof(int));
            trainingPlan.Columns.Add("TrainingArea", typeof(string));
            trainingPlan.Columns.Add("TrainingProgram", typeof(string));
            trainingPlan.Columns.Add("Remarks", typeof(string));
            trainingPlan.Columns.Add("Timeframe", typeof(string));
            trainingPlan.Columns.Add("ClosedMonth", typeof(string));
            trainingPlan.Columns.Add("Status", typeof(string));

            return trainingPlan;
        }
    }
}
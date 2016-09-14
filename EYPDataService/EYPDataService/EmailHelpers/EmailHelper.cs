using EYPDataService.DataAccess;
using EYPDataService.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace EYPDataService
{
    public static class EmailHelper
    {
        private static string EmailFrom = System.Configuration.ConfigurationManager.AppSettings["EmailFrom"];
        private static string EmailUsername = System.Configuration.ConfigurationManager.AppSettings["EmailUsername"];
        private static string EmailPassword = System.Configuration.ConfigurationManager.AppSettings["EmailPassword"];
        private static string EmailServer = System.Configuration.ConfigurationManager.AppSettings["EmailServer"];
        private static int EmailPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["EmailPort"]);

        public static void SendEmail(Feedback feedback)
        {
            if (feedback.Issues.Count > 0)
            {
                var groupedIssues = from i in feedback.Issues
                                    group i by i.Owner.EmpId into g
                                    select g;

                foreach (var issues in groupedIssues)
                {
                    SmtpClient mailClient = new SmtpClient(EmailServer, EmailPort);
                    mailClient.Credentials = new NetworkCredential(EmailUsername, EmailPassword);

                    EmployeeDataAccess dataAccess = new EmployeeDataAccess();
                    Employee employee = dataAccess.GetEmployeeDetailsByEmpId(issues.Key);

                    string emailBody = GetEmailBody(employee, issues.ToList());

                    MailMessage message = new MailMessage(EmailFrom, employee.Email, "GoWest | People Connect | Action Items for You", emailBody);
                    message.IsBodyHtml = true;
                    //create Alrternative HTML view
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(emailBody, null, "text/html");

                    //Add Image
                    LinkedResource theEmailImage = new LinkedResource(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "\\EmailHelpers\\image001.png");
                    theEmailImage.ContentId = "myImageID";

                    //Add the Image to the Alternate view
                    htmlView.LinkedResources.Add(theEmailImage);

                    //Add view to the Email Message
                    message.AlternateViews.Add(htmlView);

                    mailClient.SendAsync(message, null);
                }

            }
        }

        public static string GetEmailBody(Employee employee, List<Issue> issues)
        {
            string issuesTable = "<table class=\"MsoTableGrid\" border=\"1\" cellspacing=\"0\" cellpadding=\"0\" style='border-collapse: collapse; border: none; mso-border-alt: solid #D9D9D9 .5pt; mso-border-themecolor: background1; mso-border-themeshade: 217; mso-yfti-tbllook: 1184; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid #D9D9D9; mso-border-insideh-themecolor: background1; mso-border-insideh-themeshade: 217; mso-border-insidev: .5pt solid #D9D9D9; mso-border-insidev-themecolor: background1; mso-border-insidev-themeshade: 217'>";

            for (int i = 0; i < issues.Count; i++)
            {
                issuesTable += "<tr style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>" +
                                "<td width=\"22\" rowspan=\"3\" valign=\"top\" style='width: 16.7pt; border: solid #D9D9D9 1.0pt; mso-border-themecolor: background1; mso-border-themeshade: 217; mso-border-alt: solid #D9D9D9 .5pt; mso-border-themecolor: background1; mso-border-themeshade: 217; padding: 0cm 5.4pt 0cm 5.4pt'>" +
                                    "<p class=\"MsoNormal\" style='line-height: 115%; text-autospace: none'>" +
                                        "<b><span style='font-size: 11.0pt; line-height: 115%; font-family: \"Calibri\",\"sans-serif\"'>" + (i + 1) + "<o:p></o:p></span></b>" +
                                    "</p>" +
                                "</td>" +
                                "<td width=\"535\" colspan=\"3\" valign=\"top\" style='width: 401.0pt; border: solid #D9D9D9 1.0pt; mso-border-themecolor: background1; mso-border-themeshade: 217; border-left: none; mso-border-left-alt: solid #D9D9D9 .5pt; mso-border-left-themecolor: background1; mso-border-left-themeshade: 217; mso-border-alt: solid #D9D9D9 .5pt; mso-border-themecolor: background1; mso-border-themeshade: 217; padding: 0cm 5.4pt 0cm 5.4pt'>" +
                                    "<p class=\"MsoNormal\" style='line-height: 115%; text-autospace: none'>" +
                                        "<span style='font-size: 11.0pt; line-height: 115%; font-family: \"Calibri\",\"sans-serif\"'><b>Issue Description:</b> " + issues[i].IssueDesc +
                                            "<o:p></o:p>" +
                                        "</span>" +
                                    "</p>" +
                                    "<p class=\"MsoNormal\" style='line-height: 115%; text-autospace: none'>" +
                                        "<b><span style='font-size: 11.0pt; line-height: 115%; font-family: \"Calibri\",\"sans-serif\"'>" +
                                            "<o:p>&nbsp;</o:p>" +
                                        "</span></b>" +
                                    "</p>" +
                                "</td>" +
                            "</tr>" +
                            "<tr style='mso-yfti-irow: 1'>" +
                                "<td width=\"535\" colspan=\"3\" valign=\"top\" style='width: 401.0pt; border-top: none; border-left: none; border-bottom: solid #D9D9D9 1.0pt; mso-border-bottom-themecolor: background1; mso-border-bottom-themeshade: 217; border-right: solid #D9D9D9 1.0pt; mso-border-right-themecolor: background1; mso-border-right-themeshade: 217; mso-border-top-alt: solid #D9D9D9 .5pt; mso-border-top-themecolor: background1; mso-border-top-themeshade: 217; mso-border-left-alt: solid #D9D9D9 .5pt; mso-border-left-themecolor: background1; mso-border-left-themeshade: 217; mso-border-alt: solid #D9D9D9 .5pt; mso-border-themecolor: background1; mso-border-themeshade: 217; padding: 0cm 5.4pt 0cm 5.4pt'>" +
                                    "<p class=\"MsoNormal\" style='line-height: 115%; text-autospace: none'>" +
                                        "<span style='font-size: 11.0pt; line-height: 115%; font-family: \"Calibri\",\"sans-serif\"'><b>Action Item:</b> " + issues[i].ActionItem + "<o:p></o:p></span>" +
                                    "</p>" +
                                    "<p class=\"MsoNormal\" style='line-height: 115%; text-autospace: none'>" +
                                        "<b><span style='font-size: 11.0pt; line-height: 115%; font-family: \"Calibri\",\"sans-serif\"; color: #1F497D'>" +
                                            "<o:p>&nbsp;</o:p>" +
                                        "</span></b>" +
                                    "</p>" +
                                "</td>" +
                            "</tr>" +
                            "<tr style='mso-yfti-irow: 2'>" +
                                "<td width=\"179\" valign=\"top\" style='width: 134.2pt; border-top: none; border-left: none; border-bottom: solid #D9D9D9 1.0pt; mso-border-bottom-themecolor: background1; mso-border-bottom-themeshade: 217; border-right: solid #D9D9D9 1.0pt; mso-border-right-themecolor: background1; mso-border-right-themeshade: 217; mso-border-top-alt: solid #D9D9D9 .5pt; mso-border-top-themecolor: background1; mso-border-top-themeshade: 217; mso-border-left-alt: solid #D9D9D9 .5pt; mso-border-left-themecolor: background1; mso-border-left-themeshade: 217; mso-border-alt: solid #D9D9D9 .5pt; mso-border-themecolor: background1; mso-border-themeshade: 217; padding: 0cm 5.4pt 0cm 5.4pt'>" +
                                    "<p class=\"MsoNormal\" style='line-height: 115%; text-autospace: none'>" +
                                        "<span style='font-size: 11.0pt; line-height: 115%; font-family: \"Calibri\",\"sans-serif\"'><b>Owner: </b>" + issues[i].Owner.Name + "<o:p></o:p></span>" +
                                    "</p>" +
                                "</td>" +
                                "<td width=\"208\" valign=\"top\" style='width: 155.9pt; border-top: none; border-left: none; border-bottom: solid #D9D9D9 1.0pt; mso-border-bottom-themecolor: background1; mso-border-bottom-themeshade: 217; border-right: solid #D9D9D9 1.0pt; mso-border-right-themecolor: background1; mso-border-right-themeshade: 217; mso-border-top-alt: solid #D9D9D9 .5pt; mso-border-top-themecolor: background1; mso-border-top-themeshade: 217; mso-border-left-alt: solid #D9D9D9 .5pt; mso-border-left-themecolor: background1; mso-border-left-themeshade: 217; mso-border-alt: solid #D9D9D9 .5pt; mso-border-themecolor: background1; mso-border-themeshade: 217; padding: 0cm 5.4pt 0cm 5.4pt'>" +
                                    "<p class=\"MsoNormal\" style='line-height: 115%; text-autospace: none'>" +
                                    "<span style='font-size: 11.0pt; line-height: 115%; font-family: \"Calibri\",\"sans-serif\"'><b>Due Date:</b> " + (issues[i].DueDate.HasValue ? issues[i].DueDate.Value.ToString("dd-MMM-yyyy") : string.Empty) + "<span style='color: #1F497D'><o:p></o:p></span></span>" +
                                    "</p>" +
                                "</td>" +
                                "<td width=\"148\" valign=\"top\" style='width: 110.9pt; border-top: none; border-left: none; border-bottom: solid #D9D9D9 1.0pt; mso-border-bottom-themecolor: background1; mso-border-bottom-themeshade: 217; border-right: solid #D9D9D9 1.0pt; mso-border-right-themecolor: background1; mso-border-right-themeshade: 217; mso-border-top-alt: solid #D9D9D9 .5pt; mso-border-top-themecolor: background1; mso-border-top-themeshade: 217; mso-border-left-alt: solid #D9D9D9 .5pt; mso-border-left-themecolor: background1; mso-border-left-themeshade: 217; mso-border-alt: solid #D9D9D9 .5pt; mso-border-themecolor: background1; mso-border-themeshade: 217; padding: 0cm 5.4pt 0cm 5.4pt'>" +
                                    "<p class=\"MsoNormal\" style='line-height: 115%; text-autospace: none'>" +
                                        "<span style='font-size: 11.0pt; line-height: 115%; font-family: \"Calibri\",\"sans-serif\"'><b>Status: </b>" + Enum.GetName(typeof(Status), issues[i].Status) + "<span style='color: #1F497D'><o:p></o:p></span></span>" +
                                    "</p>" +
                                "</td>" +
                            "</tr>";

            }
            issuesTable += "</table>";
            string body = File.ReadAllText(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + System.Configuration.ConfigurationManager.AppSettings["EmailTemplatePath"]);
            body = body.Replace("[content]", issuesTable);
            body = body.Replace("[Employee Name]", employee.Name + "(" + employee.EmpId + ")");
            return body;
        }
    }
}
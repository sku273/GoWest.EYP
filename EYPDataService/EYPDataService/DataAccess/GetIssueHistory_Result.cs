//------------------------------------------------------------------------------
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
    
    public partial class GetIssueHistory_Result
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string ManagerId { get; set; }
        public string IssueDesc { get; set; }
        public string ActionItem { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string Status { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string OwnerName { get; set; }
    }
}

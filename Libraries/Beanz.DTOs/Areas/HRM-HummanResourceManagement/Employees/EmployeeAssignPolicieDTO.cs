using System;
using System.Collections.Generic;

namespace Beanz.DTOs.Areas.HummanResourceManagement.Employees
{
    public class EmployeeAssignPolicieDTO
    {
        public int EmployeeAssignPolicieID { get; set; }
        public int GosiPolicyID { get; set; }
        public int OverTimePolicyID { get; set; }
        public int AttendancePolicyID { get; set; }
        public int VacationPolicyID { get; set; }
        public int LeavePolicyID { get; set; }
        public int ShiftPolicyID { get; set; }
        public int TicketPolicyID { get; set; }
        public int LoanPolicyID { get; set; }
        public int PaidTimeOffPolicyID { get; set; }
        public int PayrollPolicyID { get; set; }
        public int AllowancePolicyID { get; set; }
        public int AdvanceSalaryPolicyID { get; set; }
        public int BusinessTripPolicyID { get; set; }
        public int HolidayPolicyID { get; set; }
        public int EndOfServicePolicyID { get; set; }
        public int InsurancePolicyID { get; set; }
        public int TrainingPolicyID { get; set; }
        public int BonusPolicyID { get; set; }
        public string EmployeeAssignPolicyCode { get; set; }
        public string EmployeeAssignPolicyName { get; set; }
        public string EmployeeAssignPolicyAlias { get; set; }
        public int EmployeeID { get; set; }
        public int CompanyID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ApprovedDate { get; set; }
        public int ApprovedBy { get; set; }
        public DateTime PostedDate { get; set; }
        public int PostedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public int DeletedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public bool IsPosted { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class EmployeeAssignPolicieViewModel
    {
        public List<EmployeeAssignPolicieDTO> EmployeeAssignPolicies { get; set; }
        public EmployeeAssignPolicieDTO EmployeeAssignPolicie { get; set; }
    }
}

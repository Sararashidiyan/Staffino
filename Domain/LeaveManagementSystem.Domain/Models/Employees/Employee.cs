using System;
using LeaveManagementSystem.Domain.Contract.Enums;
using LeaveManagementSystem.Framework;

namespace LeaveManagementSystem.Domain.Models.Employees
{
    public class Employee:EntityBase<long,Employee>,IAggregateRoot
    {
        public Employee()
        {
            
        }

        public string EmployeeId { get;private set; }
        public int PositionId { get;private set; }
        public int DepartmentId { get;private set; }
        public string FirstName { get;private set; }
        public string LastName { get;private set; }
        public string MiddleName { get;private set; }
        public DateTime DateOfBirth { get;private set; }
        public DateTime PlaceOfBirth { get;private set; }
        public string ContactNo { get;private set; }
        public string Address { get;private set; }
        public DateTime HiredDate { get;private set; }
        public PayMethodEnum PayMethod { get;private set; }
        public CivilStatusEnum CivilStatus { get;private set; }
        public SexEnum Sex { get;private set; }
    }
}

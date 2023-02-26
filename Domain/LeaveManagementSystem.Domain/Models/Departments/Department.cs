using System.Collections.Generic;
using LeaveManagementSystem.Domain.Models.Positions;
using LeaveManagementSystem.Framework;

namespace LeaveManagementSystem.Domain.Models.Departments
{
   public class Department:EntityBase<int,Department>,IAggregateRoot
    {
        public Department()
        {
            
        }

        public static Department Create(string title)
        {
            return new Department(title);
        }

        public void Update(string title)
        {
            Title = title;
        }
        private Department(string title)
        {
            Title = title;
            IsActive = true;
            IsDeleted = false;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
        public void DeActivate()
        {
            IsActive = false;
        }
        public void Activate()
        {
            IsActive = true;
        }
        public string Title { get;private set; }
        public bool IsDeleted { get;private set; }
        public bool IsActive { get;private set; }
        public List<Position> Positions { get; private set; }
    }
}

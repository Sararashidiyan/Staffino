using LeaveManagementSystem.Domain.Models.Departments;
using LeaveManagementSystem.Framework;

namespace LeaveManagementSystem.Domain.Models.Positions
{
   public class Position:EntityBase<int,Position>
    {
        public Position()
        {
            
        }

        private Position(string title,int departmentId)
        {
            Title = title;
            IsActive = true;
            IsDeleted = false;
            DepartmentId = departmentId;
        }
        public void Update(string title)
        {
            Title = title;
        }
        public static Position Create(string title, int departmentId)
        {
            return new Position(title,  departmentId);
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
        public bool IsActive { get; private set; }
        public bool IsDeleted { get; private set; }
        public int DepartmentId { get; private set; }
        public Department Department { get; private set; }
    }
}

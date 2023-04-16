using LeaveManagementSystem.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Domain.Models.Positions
{
    public interface IPositionRepository: IRepository<Position,int>
    {
        List<Position> GetByDepartmentId(int departmentId);
    }
    public interface IUserRepository : IRepository<User, int>
    {
        List<Position> GetByDepartmentId(int departmentId);
    }
}

using LeaveManagementSystem.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Domain.Models.Positions
{
    public interface IPositionRepository: IRepository<Position,int>
    {
    }
}

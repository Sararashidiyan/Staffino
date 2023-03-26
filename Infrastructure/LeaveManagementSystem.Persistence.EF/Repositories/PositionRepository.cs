using System;
using System.Collections.Generic;
using System.Text;
using LeaveManagementSystem.Domain.Models.Positions;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Persistence.EF.Repositories
{
    public class PositionRepository:BaseRepository<Position,int>, IPositionRepository
    {
        public PositionRepository(LeaveManagementDbContext context) : base(context)
        {
        }
    }
}

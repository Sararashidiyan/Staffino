using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeaveManagementSystem.Domain.Models.Positions;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Persistence.EF.Repositories
{
    public class PositionRepository:BaseRepository<Position,int>, IPositionRepository
    {
        private readonly LeaveManagementDbContext _context; 
        public PositionRepository(LeaveManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Position> GetByDepartmentId(int departmentId)
        {
            return _context.Set<Position>().Where(p => p.DepartmentId == departmentId).ToList();
        }
    }
}

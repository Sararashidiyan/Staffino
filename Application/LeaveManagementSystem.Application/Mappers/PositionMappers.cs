using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeaveManagementSystem.Application.Contract.Position.Dtos;
using LeaveManagementSystem.Domain.Models.Positions;

namespace LeaveManagementSystem.Application.Mappers
{
    public static class PositionMappers
    {
        public static PositionDto Map(Position item)
        {
            return new PositionDto()
            {
              Title   = item.Title,
              DepartmentName = item.DepartmentName,
              Id = item.Id
            };
        }

        public static List<PositionDto> Map(List<Position> items)
        {
            return items?.Select(Map).ToList();
        }
    }
}

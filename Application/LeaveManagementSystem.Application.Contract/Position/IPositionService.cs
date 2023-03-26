using System;
using System.Collections.Generic;
using System.Text;
using LeaveManagementSystem.Application.Contract.Position.Dtos;
using LeaveManagementSystem.Core;

namespace LeaveManagementSystem.Application.Contract.Position
{
    public interface IPositionService
    {
        [HasPermission("")]
        PositionDto GetById(int id);
        void Create(CreatePositionDto item);
        void Modify(ModifyPositionDto item);
        void Activate(int id);
        void DeActivate(int id);
        void Delete(int id);
    }
}

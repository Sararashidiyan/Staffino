using System.Threading.Tasks;
using LeaveManagementSystem.Application.Contract.Position;
using LeaveManagementSystem.Application.Contract.Position.Dtos;
using LeaveManagementSystem.Application.Contract.User;
using LeaveManagementSystem.Core.BusinessExceptions;
using LeaveManagementSystem.Domain.Models.Positions;

namespace LeaveManagementSystem.Application
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public void Create(CreatePositionDto item)
        {
            var positionToCreate = Position.Create(item.Title,item.DepartmentId,item.DepartmentName);
            _positionRepository.Create(positionToCreate);
        }
        public PositionDto GetById(int id)
        {
            var position = _positionRepository.GetById(id);
            if (position==null)
                throw new NotFoundException();
            return new PositionDto(){Id=position.Id,DepartmentName = position.DepartmentName,Title=position.Title};
        }
    }
}
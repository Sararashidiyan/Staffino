using System.Collections.Generic;
using System.Threading.Tasks;
using LeaveManagementSystem.Application.Contract.Position.Dtos;
using LeaveManagementSystem.Application.Contract.User;
using LeaveManagementSystem.Application.Mappers;
using LeaveManagementSystem.Core.BusinessExceptions;
using LeaveManagementSystem.Domain.Models.Positions;

namespace LeaveManagementSystem.Application
{
    public class UserService : IUserService
    {
        public Task<UserDto> GetCurrentUser()
        {
            return null;
           //var currentUser=
        }


        private readonly IPositionRepository _positionRepository;
        public UserService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }
        public List<PositionDto> GetByDepartmentId(int departmentId)
        {
            var positions = _positionRepository.GetByDepartmentId(departmentId);
            return PositionMappers.Map(positions);
        }

        public void Create(CreatePositionDto item)
        {
            var positionToCreate = Position.Create(item.Title, item.DepartmentId, item.DepartmentName);
            _positionRepository.Create(positionToCreate);
        }

        public void Modify(ModifyPositionDto item)
        {
            var position = _positionRepository.GetById(item.Id);
            if (position == null)
                throw new NotFoundException();
            position.Update(position.Title);
        }

        public void Activate(int id)
        {
            var position = _positionRepository.GetById(id);
            if (position == null)
                throw new NotFoundException();
            position.Activate();
        }

        public void DeActivate(int id)
        {
            var position = _positionRepository.GetById(id);
            if (position == null)
                throw new NotFoundException();
            position.DeActivate();
        }

        public void Delete(int id)
        {
            var position = _positionRepository.GetById(id);
            if (position == null)
                throw new NotFoundException();
            position.Delete();
        }

        public PositionDto GetById(int id)
        {
            var position = _positionRepository.GetById(id);
            if (position == null)
                throw new NotFoundException();
            return PositionMappers.Map(position);
        }
    }
}

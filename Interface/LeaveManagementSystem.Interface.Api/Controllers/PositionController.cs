using LeaveManagementSystem.Application.Contract.Position;
using LeaveManagementSystem.Application.Contract.Position.Dtos;
using LeaveManagementSystem.Interface.Api.CustomActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Interface.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService; 
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet("GetById")]
        public ActionResult GetById(int id)
        {
            var position = _positionService.GetById(id);
            return Ok(position);
        }
        [HttpGet("GetByDepartmentId")]
        public ActionResult Get(int departmentId)
        {
            var positions = _positionService.GetByDepartmentId(departmentId);
            return Ok(positions);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public ActionResult Post(CreatePositionDto item)
        {
            _positionService.Create(item);
            return Ok();
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("Modify")]
        public ActionResult Put(ModifyPositionDto item)
        {
            _positionService.Modify(item);
            return Ok();
        }
        [HttpPut("DeActivate")]
        public ActionResult DeActivate(int id)
        {
            _positionService.DeActivate(id);
            return Ok();
        }
        [HttpPut("Activate")]
        public ActionResult Activate(int id)
        {
            _positionService.DeActivate(id);
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _positionService.Delete(id);
            return Ok();
        }
    }
}

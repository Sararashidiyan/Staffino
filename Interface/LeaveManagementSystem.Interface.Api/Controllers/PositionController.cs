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
        public ActionResult Get()
        {
            return Ok(new PositionDto());
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public ActionResult Post(CreatePositionDto item)
        {
            _positionService.Create(item);
            return Ok();
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut]
        public ActionResult Put(ModifyPositionDto item)
        {
            return null;
        }
        [HttpPut]
        public ActionResult DeActivate(DeActivatePositionDto item)
        {
            return null;
        }
        [HttpPut]
        public ActionResult Activate(ActivatePositionDto item)
        {
            return null;
        }
        [HttpPut]
        public ActionResult Delete(int id)
        {
            return null;
        }
    }
}

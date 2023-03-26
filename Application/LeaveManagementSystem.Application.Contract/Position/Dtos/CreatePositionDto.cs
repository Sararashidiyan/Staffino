namespace LeaveManagementSystem.Application.Contract.Position.Dtos
{
    public class CreatePositionDto : Dto
    {
        public string Title { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
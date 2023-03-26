namespace LeaveManagementSystem.Application.Contract.Position.Dtos
{
    public class PositionDto : Dto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DepartmentName { get; set; }
    }
}
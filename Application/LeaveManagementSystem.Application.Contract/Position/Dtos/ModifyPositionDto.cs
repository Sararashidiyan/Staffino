namespace LeaveManagementSystem.Application.Contract.Position.Dtos
{
    public class ModifyPositionDto : Dto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class ActivatePositionDto : Dto
    {
        public int Id { get; set; }
    }
    public class DeActivatePositionDto : Dto
    {
        public int Id { get; set; }
    }
}
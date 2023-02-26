using LeaveManagementSystem.Domain.Models.Departments;
using Xunit;

namespace LeaveManagementSystem.Domain.Test
{
    public class DepartmentTests
    {

        [Fact]
        public void Create_Should_Add_New_Department()
        {
            //Arrange
            var departmentTitle = "IT";
            var department =  Department.Create(departmentTitle);
            //Assert
            Assert.Equal( departmentTitle,department.Title);
            Assert.True(department.IsActive);
            Assert.False(department.IsDeleted);
        }
        [Fact]
        public void Update_Should_Modify_Existed_Department()
        {
            //Arrange
            var departmentTitle = "IT";
            var newDepartmentTitle = "Seo";
            var department = Department.Create(departmentTitle);
            //Act
            department.Update(newDepartmentTitle);
            //Assert
            Assert.Equal(newDepartmentTitle,department.Title );
        }
        [Fact]
        public void DeActivate_Should_DeActive_Active_Department()
        {
            //Arrange
            var departmentTitle = "IT";
            var department = Department.Create(departmentTitle);
            //Act
            department.DeActivate();
            //Assert
            Assert.False(department.IsActive);
        }
        [Fact]
        public void Activate_Should_Active_DeActive_Department()
        {
            //Arrange
            var departmentTitle = "IT";
            var department = Department.Create(departmentTitle);
            department.DeActivate();
            //Act
            department.Activate();
            //Assert
            Assert.True(department.IsActive);
        }
    }
}
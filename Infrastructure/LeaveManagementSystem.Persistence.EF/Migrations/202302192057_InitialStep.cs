using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;

namespace LeaveManagementSystem.Persistence.EF.Migrations
{
    [Migration(1)]
    public class _202302192057_InitialStep:Migration
    {
        public override void Up()
        {
            Create.Table("Department").InSchema("dbo")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable()
                .WithColumn("CreateDateTime").AsDateTime().NotNullable()
                .WithColumn("UserId").AsGuid().NotNullable()
                .WithColumn("LastEditDateTime").AsDateTime().Nullable();

            Create.Table("Position").InSchema("dbo")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("DepartmentId").AsInt32().NotNullable().NotNullable()
                .WithColumn("DepartmentName").AsString().NotNullable()
                .WithColumn("Title").AsString().NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable()
                .WithColumn("CreateDateTime").AsDateTime().NotNullable()
                .WithColumn("UserId").AsGuid().NotNullable()
                .WithColumn("LastEditDateTime").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Department");
            Delete.Table("Position");
        }
    }
   
}

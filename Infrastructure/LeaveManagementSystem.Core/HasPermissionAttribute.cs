using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Core
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HasPermissionAttribute : Attribute
    {
        public Permission Permission { get; private set; }

        public HasPermissionAttribute(object permission)
        {
            Permission = new Permission()
            {
                Code=Convert.ToInt32(permission),
                Name=permission.ToString()
            };
        }
    }

    public class IgnorePermissionAttribute : Attribute
    {
    }
    public class Permission
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }
}

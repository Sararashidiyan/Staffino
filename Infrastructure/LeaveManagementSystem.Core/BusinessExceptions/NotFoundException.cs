using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Core.BusinessExceptions
{
    public class NotFoundException:BusinessException
    {
        public NotFoundException():base(1,"مورد مورد نظر یافت نشد")
        {
            
        }
    }
}

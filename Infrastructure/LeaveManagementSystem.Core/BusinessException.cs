using System;

namespace LeaveManagementSystem.Core
{
    public class BusinessException:Exception
    {
        public int Code { get;private set; }   
        public BusinessException()
        {
            
        }
        public BusinessException(int code,string message):base(message)
        {
            Code = code;

        }
       
    }
}

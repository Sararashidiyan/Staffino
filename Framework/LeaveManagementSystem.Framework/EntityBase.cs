using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Framework
{
    public class EntityBase<TKey,T> where T :EntityBase<TKey, T>
    {
        public TKey Id { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreateDateTime { get;private set; }
        public DateTime LastEditDateTime { get; private set; }

        public EntityBase()
        {
            CreateDateTime=DateTime.Now;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using LeaveManagementSystem.Framework;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Persistence.EF.Repositories
{
    public abstract class BaseRepository<T, TKey> :IRepository<T, TKey> where T: class, IAggregateRoot
    {
        private readonly LeaveManagementDbContext _context;

        protected BaseRepository(LeaveManagementDbContext context)
        {
            _context = context;
        }
        public virtual T GetById(TKey id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Create(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }
    }
}

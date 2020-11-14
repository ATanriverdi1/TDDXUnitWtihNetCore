using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TddBlogDevto.Entity.Repository
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public User Post(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}

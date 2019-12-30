using Medicine.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Repository
{
    public class UserUnitOfWork : IDisposable
    {
        private MedicineDbContext _context;
        private UserRepository _userRepository;
        public UserUnitOfWork(MedicineDbContext context)
        {
            _context = context;
            _userRepository = new UserRepository(_context);
        }

        public UserRepository UserRepository => _userRepository; 

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

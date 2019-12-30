using Medicine.Entities;
using Medicine.Repository.Base;
using Medicine.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Repository
{
    public class UserRepository : Repository<User>
    {
        private MedicineDbContext _context;
        public UserRepository(MedicineDbContext context) : base(context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return base.Get(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
    }
}

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
    public class MedicineRepository : Repository<MedicineInfo>
    {
        private MedicineDbContext _context;

        public MedicineRepository(MedicineDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

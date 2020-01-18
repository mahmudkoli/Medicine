using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Common
{
    public enum EnumMedicineStatus
    {
        Draft = 1,
        Pending = 2,
        Approved = 3,
        Banned = 4
    }
    public enum EnumMedicineReportStatus
    {
        Draft = 1,
        Pending = 2,
        Rejected = 3,
        ToComapny = 4,
        ToPharmacy = 5,
        Completed = 6
    }
}

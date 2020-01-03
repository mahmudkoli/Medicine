using Medicine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Common
{
    public static class CustomColor
    {
        public static string BadgeColor(EnumMedicineStatus val)
        {
            switch (val)
            {
                case EnumMedicineStatus.Approved:
                    return "badge-success";
                case EnumMedicineStatus.Banned:
                    return "badge-error";
                case EnumMedicineStatus.Pending:
                    return "badge-warning";
                case EnumMedicineStatus.Draft:
                    return "";
                default:
                    return "";
            }
        }
        public static string BadgeColor(EnumMedicineReportStatus val)
        {
            switch (val)
            {
                case EnumMedicineReportStatus.Done:
                case EnumMedicineReportStatus.ToPharmacy:
                case EnumMedicineReportStatus.ToComapny:
                    return "badge-success";
                case EnumMedicineReportStatus.Rejected:
                    return "badge-error";
                case EnumMedicineReportStatus.Pending:
                    return "badge-warning";
                case EnumMedicineReportStatus.Draft:
                    return "";
                default:
                    return "";
            }
        }
    }
}

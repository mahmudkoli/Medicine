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
                    return "badge-warning";
                case EnumMedicineStatus.Pending:
                    return "badge-warning";
                case EnumMedicineStatus.Draft:
                    return "";
                default:
                    return "";
            }
        }
        public static string CardColor(EnumMedicineStatus val)
        {
            switch (val)
            {
                case EnumMedicineStatus.Approved:
                    return "approved-card";
                case EnumMedicineStatus.Banned:
                    return "hold-permanetly-card";
                case EnumMedicineStatus.Pending:
                    return "pending-card";
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
                    return "badge-warning";
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

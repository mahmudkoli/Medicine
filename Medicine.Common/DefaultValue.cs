using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Common
{
    public static class DefaultValue
    {
        public const string CompanyFullName = "Medicine";
        public const string CompanyShortName = "MDC";
        public const string DeveloperCompanyFullName = "Mahmud Koli";
        public const string DeveloperCompanyShortName = "MK";
        public const string UserPassword = "12345";

        public static List<string> MedicineTypes => new List<string> { "Tablet", "Capsule", "Syrup" };

        public static List<string> MedicineSizes => new List<string> { "100 mg", "250 mg", "400 mg", "500 mg" };
    }
    public static class Role
    {
        public const string Admin = "Admin";
        public const string NormalUser = "NormalUser";
    }
    public static class EmailType
    {
        public const string VerifyAccount = "VerifyAccount";
        public const string ResetPassword = "ResetPassword";
    }
}

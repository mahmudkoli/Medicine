using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Common
{
    public static class DefaultValue
    {
        public static string CompanyFullName => "Medicine";
        public static string CompanyShortName => "MDC";
        public static string DeveloperCompanyFullName => "Mahmud Koli";
        public static string DeveloperCompanyShortName => "MK";
        public static string UserPassword => "12345";
        public static Role Role => new Role();
    }
    public class Role
    {
        public string Admin => "Admin";
        public string NormalUser => "NormalUser";
    }
}

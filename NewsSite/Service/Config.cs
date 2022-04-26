using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Service
{
    /// <summary>
    /// Configuration from appseting.json file.
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Connection string to DataBase.
        /// </summary>
        public static string ConnectionString { get; set; }

        /// <summary>
        /// Company name.
        /// </summary>
        public static string CompanyName { get; set; }

        /// <summary>
        /// Full version of company's phone number.
        /// </summary>
        public static string CompanyPhone { get; set; }

        /// <summary>
        /// Short version of company's phone number.
        /// </summary>
        public static string CompanyPhoneShort { get; set; }

        /// <summary>
        /// Company email.
        /// </summary>
        public static string CompanyEmail { get; set; }
    }
}

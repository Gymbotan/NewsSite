using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Service
{
    /// <summary>
    /// Class for Extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Cut off "Controller" part from controller's name.
        /// </summary>
        /// <param name="str">Controller's name.</param>
        /// <returns>Shorter name.</returns>
        public static string CutController(this string str)
        {
            return str.Replace("Controller", "");
        }
    }
}

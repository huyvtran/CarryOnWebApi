using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public class LogHelper
    {
        public const string PARAMETER_SEPARATOR = ", ";

        /// <summary>
        /// Inspects the specified variable returning the string representation.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns></returns>
        public static string Inspect(object variable)
        {
            if (variable == null) return "null";
            if (variable is ICollection)
            {
                bool appended = false;
                var v = new StringBuilder();
                v.Append("[");
                foreach (var item in (ICollection)variable)
                {
                    v.Append(item.ToString() + PARAMETER_SEPARATOR);
                    appended = true;
                }
                if (appended) v.Remove(v.Length - LogHelper.PARAMETER_SEPARATOR.Length, LogHelper.PARAMETER_SEPARATOR.Length);//Remove the last PARAMETER_SEPARATOR character
                v.Append("]");
                return v.ToString();
            }
            else
            {
                return variable.ToString();
            }
        }
    }
}

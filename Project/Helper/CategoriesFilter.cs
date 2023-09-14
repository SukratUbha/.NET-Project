using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Helper
{
    public class CategoriesFilter
    {
        public static string Filter(string c)
        {
            string[] subStrings = c.Split(',');
            for (int k = 0; k < subStrings.Length; k++)
            {
                subStrings[k] = subStrings[k].Trim();
            }
            StringBuilder updated_string = new StringBuilder();
            foreach (string x in subStrings)
            {
                updated_string.Append(x).Append(",");
            }
            updated_string.Remove(updated_string.Length - 1, 1);
            return updated_string.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Variel.Helpers
{
    public static class ObjectExtension
    {
        public static Dictionary<string, string> ToStringDictionary(this object data)
        {
            const BindingFlags attr = BindingFlags.Public | BindingFlags.Instance;

            return data.GetType()
                       .GetProperties(attr)
                       .Where(property => property.CanRead)
                       .ToDictionary(
                           property => property.Name,
                           property => property.GetValue(data, null).ToString()
                       );
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MLA.ClientOrder.Common.Extesntions
{
    public static class EnumExtension
    {
        public static List<KeyValuePair<string, string>> GetList<TEnum>() where TEnum : Enum
        {
            if (!typeof(TEnum).IsEnum) throw new InvalidOperationException();
            return ((TEnum[])Enum.GetValues(typeof(TEnum)))
               .ToDictionary(k => Enum.GetName(typeof(TEnum), (object)k)
                    , v => ((Enum)v).GetEnumDisplayName())
               .ToList();
        }
        public static string GetEnumDisplayName(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Name;
            else
                return value.ToString();
        }

        public static bool IsEnumExist<TEnum>(string value) where TEnum : Enum
        {
            return Enum.IsDefined(typeof(TEnum), value);
        }
    }
}

using NPOI.SS.Formula.Functions;
using StorageSystem.Application.Enums.ErrorMessage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            return enumValue.GetType().GetField(enumValue.ToString())?.GetCustomAttributes<DescriptionAttribute>() is
                DescriptionAttribute descriptionAttribute
                ? descriptionAttribute.Description : enumValue.ToString();
        }

        public static string ToCode(this ErrorMessage value)
        {
            return ((int)value).ToString();
        }

        public static IQueryable<T> Paginate(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            return source.Skip((Math.Max(1, pageNumber) - 1) * pageSize).Take(pageSize);
        }
    }
}

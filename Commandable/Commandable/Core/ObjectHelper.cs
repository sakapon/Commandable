﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Commandable.Core
{
    public static class ObjectHelper
    {
        public static T To<T>(this object value) => (T)value.ConvertType(typeof(T));

        public static object ConvertType(this object value, Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return value?.ConvertType(type.GenericTypeArguments[0]);
            }
            if (type.IsEnum)
            {
                if (value == null) throw new InvalidCastException("The null value can not be converted to a value type.");

                return Enum.Parse(type, value.ToString(), true);
            }
            if (type == typeof(TimeSpan))
            {
                if (value == null) throw new InvalidCastException("The null value can not be converted to a value type.");

                return TimeSpan.Parse(value.ToString());
            }
            if (type == typeof(DateTimeOffset))
            {
                if (value == null) throw new InvalidCastException("The null value can not be converted to a value type.");

                return DateTimeOffset.Parse(value.ToString());
            }
            return Convert.ChangeType(value, type);
        }
    }
}

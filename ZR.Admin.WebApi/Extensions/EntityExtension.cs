﻿
using System.Reflection;

namespace ZR.Admin.WebApi.Extensions
{
    public static class EntityExtension
    {
        public static TSource ToCreate<TSource>(this TSource source, HttpContext? context = null)
        {
            var types = source?.GetType();
            if (types == null) return source;
            BindingFlags flag = BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance;

            types.GetProperty("CreateTime", flag)?.SetValue(source, DateTime.Now, null);
            types.GetProperty("AddTime", flag)?.SetValue(source, DateTime.Now, null);
            types.GetProperty("CreateBy", flag)?.SetValue(source, context.GetName(), null);
            types.GetProperty("Create_by", flag)?.SetValue(source, context.GetName(), null);
            types.GetProperty("UserId", flag)?.SetValue(source, context.GetUId(), null);

            return source;
        }

        public static TSource ToUpdate<TSource>(this TSource source, HttpContext? context = null)
        {
            var types = source?.GetType();
            if (types == null) return source;
            BindingFlags flag = BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance;

            types.GetProperty("UpdateTime", flag)?.SetValue(source, DateTime.Now, null);
            types.GetProperty("Update_time", flag)?.SetValue(source, DateTime.Now, null);
            types.GetProperty("UpdateBy", flag)?.SetValue(source, context.GetName(), null);
            types.GetProperty("Update_by", flag)?.SetValue(source, context.GetName(), null);

            return source;
        }

    }
}

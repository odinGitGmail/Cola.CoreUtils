﻿using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Cola.CoreUtils.Enums;
using Newtonsoft.Json;

namespace Cola.CoreUtils.Extensions;

/// <summary>
///     ObjectExtensions
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    ///     转换 对象 为 Dictionary&lt;string, string&gt;类型
    /// </summary>
    /// <param name="obj">泛型对象</param>
    /// <param name="encoder">字符编码</param>
    /// <typeparam name="T">泛型类型</typeparam>
    /// <returns>Dictionary&lt;string, string&gt;类型</returns>
    public static Dictionary<string, string?> ConvertObjectToDictionary<T>(this T obj)
        where T : class
    {
        return JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(obj))!;
    }

    /// <summary>
    ///     对象转 JsonString
    /// </summary>
    /// <param name="obj">需要转换的对象</param>
    /// <param name="stringFormat">是否需要json格式化输出</param>
    /// <returns>转换后的string</returns>
    public static string ToJson(this object obj, EnumStringFormat stringFormat = EnumStringFormat.None)
    {
        if (stringFormat == EnumStringFormat.None)
            return JsonConvert.SerializeObject(obj);
        return JsonConvert.SerializeObject(obj).ToJsonFormatString();
    }

    /// <summary>
    ///     可以处理复杂映射
    /// </summary>
    /// <typeparam name="TIn">输入类</typeparam>
    /// <typeparam name="TOut">输出类</typeparam>
    /// <param name="expression">表达式目录树,可以为null</param>
    /// <param name="tIn">输入实例</param>
    /// <returns></returns>
    public static TOut Mapper<TIn, TOut>(this TIn tIn, Expression<Func<TIn, TOut>>? expression = null)
    {
        ParameterExpression? parameterExpression = null;
        var memberBindingList = new List<MemberBinding>();
        parameterExpression = Expression.Parameter(typeof(TIn), "p");

        if (expression != null)
        {
            parameterExpression = expression.Parameters[0];
            {
                var readOnlyCollection = (expression.Body as MemberInitExpression)?.Bindings;
                if (readOnlyCollection != null)
                    memberBindingList.AddRange(readOnlyCollection);
            }
        }

        foreach (var item in typeof(TOut).GetProperties())
        {
            if (typeof(TIn).GetProperty(item.Name) != null)
            {
                var property =
                    Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name)!);
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }

            if (typeof(TIn).GetField(item.Name) != null)
            {
                var property = Expression.Field(parameterExpression, typeof(TIn).GetField(item.Name)!);
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }
        }

        foreach (var item in typeof(TOut).GetFields())
        {
            if (typeof(TIn).GetField(item.Name) != null)
            {
                var property = Expression.Field(parameterExpression, typeof(TIn).GetField(item.Name)!);
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }

            if (typeof(TIn).GetProperty(item.Name) != null)
            {
                var property =
                    Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name)!);
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }
        }

        var memberInitExpression =
            Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());

        var lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, parameterExpression);
        var func = lambda.Compile(); //获取委托
        return func.Invoke(tIn);
    }
}
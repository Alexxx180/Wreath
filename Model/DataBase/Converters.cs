using System;
using System.Collections.Generic;

namespace Wreath.Model.DataBase
{
    /// <summary>
    /// Converters used for converting database objects to string fields
    /// </summary>
    public static class Converters
    {
        public static TOutput[] ConvertAll<TInput, TOutput>(TInput[] array, Func<TInput, TOutput> converter)
        {
            TOutput[] result = new TOutput[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = converter(array[i]);
            }
            return result;
        }


        public static List<TOutput> ConvertAll<TInput, TOutput>(List<TInput> list, Func<TInput, TOutput> converter)
        {
            List<TOutput> result = new List<TOutput>();
            for (int i = 0; i < list.Count; i++)
            {
                result.Add(converter(list[i]));
            }
            return result;
        }

        public static string ElementToString(object value) => value.ToString();
        public static string[] ElementsToString(object[] values) => ConvertAll(values, ElementToString);
    }
}
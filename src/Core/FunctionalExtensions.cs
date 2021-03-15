using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageExt.Common;

namespace Core
{
    public static class FunctionalExtensions
    {
        public static Task<T> ToTask<T>(this T v) => Task.FromResult(v);
        public static Result<T> ToResult<T>(this T v) => v;
        public static TResult AsEntity<TResult, TItem>(this IEnumerable<TItem> messages,
            Func<TResult, TItem, TResult> reducer, TResult seed) => messages.Aggregate(seed, reducer);

        public static T Identity<T>(T item) => item;
    }
}
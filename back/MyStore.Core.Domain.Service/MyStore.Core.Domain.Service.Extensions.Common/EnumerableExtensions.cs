namespace MyStore.Core.Domain.Service.Extensions.Common
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if(source == null) throw new ArgumentNullException("The provided source sequence was null");
            if (predicate == null) throw new ArgumentNullException("The provided predicate was null");
            foreach (TSource item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException("The provided source sequence was null");
            if (selector == null) throw new ArgumentNullException("The provided selector was null");
            foreach (TSource item in source)
                yield return selector(item);
        }

        public static TSource MyMax<TSource>(this IEnumerable<TSource> source) where TSource : IComparable<TSource>
        {
            if(source == null) throw new ArgumentNullException("The provided source sequence was null");
            source = source.Where(x => x != null);
            if (source.EmptyOrAllNull()) throw new InvalidOperationException("The provided source sequence was empty or did only contain null references");
            TSource max = source.First();
            foreach (TSource item in source)
            {
                if (item.CompareTo(max) > 0)
                    max = item;
            }
            return max;
        }

        /// <summary>
        /// Returns true if the provided source is empty or contains only null elements,
        /// otherwise returns false.
        /// </summary>
        /// <typeparam name="TSource">Type of the elements</typeparam>
        /// <param name="source">Provided element sequence</param>
        /// <returns></returns>
        public static bool EmptyOrAllNull<TSource>(this IEnumerable<TSource> source)
        {
            return !source.Any()
                || source.All(x => x == null);
        }
    }
}

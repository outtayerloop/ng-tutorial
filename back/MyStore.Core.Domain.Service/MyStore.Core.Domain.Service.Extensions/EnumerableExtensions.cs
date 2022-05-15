namespace MyStore.Core.Domain.Service.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            int count = source.Count();
            TSource currentElement;
            for(int i = 0; i < count; ++i)
            {
                currentElement = source.ElementAt(i);
                if (predicate(currentElement))
                    yield return currentElement;
            }
        }

        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            int count = source.Count();
            TSource currentElement;
            for (int i = 0; i < count; ++i)
            {
                currentElement = source.ElementAt(i);
                yield return selector(currentElement);
            }
        }

        public static int MyMax(this IEnumerable<int> source)
        {
            int count = source.Count();
            if (count == 0)
                throw new InvalidOperationException("The given source sequence contains no element");
            int max = int.MinValue;
            for (int i = 0; i < count; ++i)
            {
                if(source.ElementAt(i) > max)
                    max = source.ElementAt(i);
            }
            return max;
        }
    }
}

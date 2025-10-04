namespace SharedProject.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        public static void ThrowIfNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Collection cannot be null.");
            }

            if (!source.Any())
            {
                throw new ArgumentException("Collection cannot be empty.", nameof(source));
            }
        }
    }

}

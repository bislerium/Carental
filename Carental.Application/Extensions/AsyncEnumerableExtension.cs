namespace Carental.Application.Extensions
{
    public static class AsyncEnumerableExtension
    {
        public static async Task<List<TEntity>> ToListAsync<TEntity>(this IAsyncEnumerable<TEntity> asyncEnumerable)
        {
            List<TEntity> list = new();
            await foreach(var entity in asyncEnumerable)
            {
                list.Add(entity);
            }
            return list;
        }
    }
}

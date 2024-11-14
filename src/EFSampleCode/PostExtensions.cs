namespace EFSampleCode
{
    internal static class PostExtensions
    {
        internal static IQueryable<Post> ExcludeDeleted(this IQueryable<Post> postsQuery)
        {
            return postsQuery.Where(p => !p.IsDeleted);
        }
    }
}
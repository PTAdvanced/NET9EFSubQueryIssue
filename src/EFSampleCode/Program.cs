using EFSampleCode;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Read
Console.WriteLine("Querying with a sub query referencing an extension method");
var exampleQuery = db.Blogs.Join(
    db.Posts.ExcludeDeleted(),
    blog => blog.BlogId,
    post => post.BlogId,
    (blog, post) => new { blog, post })
    .ToList();

Console.WriteLine($"Number results: {exampleQuery.Count}");

var exampleQuery2 = db.Blogs.Select(b => new
{
    b.BlogId,
    posts = b.Posts.Join(
        db.Posts.ExcludeDeleted(),
        outer => outer.PostId,
        inner => inner.PostId,
        (outer, inner) => new { outer, inner })
})
.ToList();

Console.WriteLine($"Number results: {exampleQuery2.Count}");

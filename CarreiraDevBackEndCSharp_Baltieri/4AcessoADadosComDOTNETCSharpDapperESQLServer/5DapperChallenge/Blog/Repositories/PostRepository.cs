using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;

namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>
    {
        public List<Post> GetPostWithTags()
        {
            var query = @"
            SELECT
                [Post].*,
                [Tag].*
            FROM
                [Post]
                LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]";

            var posts = new List<Post>();

            var items = Database.Connection.Query<Post, Tag, Post>(
                query,
                (post, tag) =>
                {
                    var pst = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (pst == null)
                    {
                        pst = post;
                        if (tag != null)
                            pst.Tags.Add(tag);
                        posts.Add(pst);
                    }
                    else
                        pst.Tags.Add(tag);

                    return post;
                }, splitOn: "Id");

            return posts;
        }
    }
}
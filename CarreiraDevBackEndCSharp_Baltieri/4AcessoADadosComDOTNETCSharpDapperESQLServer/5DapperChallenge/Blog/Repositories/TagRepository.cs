using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;

namespace Blog.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        public List<Tag> GetTagWithPostQuantity()
        {
            var query = @"
            SELECT
                [Tag].[Name],
                [Post].[Title]
            FROM
                [Tag]
                INNER JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id]
                INNER JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]";

            var tags = new List<Tag>();

            var items = Database.Connection.Query<Tag, Post, Tag>(
                query,
                (tag, post) =>
                {
                    var tg = tags.FirstOrDefault(x => x.Id == tag.Id);
                    if (tg == null)
                    {
                        tg = tag;
                        if (tag != null)
                            tg.Posts.Add(post);
                        tags.Add(tg);
                    }
                    else
                        tg.Posts.Add(post);

                    return tag;
                }, splitOn: "Title");

            return tags;
        }
    }
}
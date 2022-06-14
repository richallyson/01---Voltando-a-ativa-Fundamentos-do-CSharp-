// using System.Collections.Generic;
// using System.Linq;
// using Blog.Models;
// using Dapper;

// namespace Blog.Repositories
// {
//     public class CategoryRepository : Repository<Category>
//     {
//         public List<Category> GetPostWithTags()
//         {
//             var query = @"
//             SELECT
//                 [Post].*,
//                 [Tag].*
//             FROM
//                 [Post]
//                 LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
//                 LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]";

//             var categories = new List<Category>();

//             var items = Database.Connection.Query<Category, Post, Category>(
//                 query,
//                 (post, tag) =>
//                 {
//                     var pst = posts.FirstOrDefault(x => x.Id == post.Id);
//                     if (pst == null)
//                     {
//                         pst = post;
//                         if (tag != null)
//                             pst.Tags.Add(tag);
//                         posts.Add(pst);
//                     }
//                     else
//                         pst.Tags.Add(tag);

//                     return post;
//                 }, splitOn: "Id");

//             return posts;
//         }
//     }
// }
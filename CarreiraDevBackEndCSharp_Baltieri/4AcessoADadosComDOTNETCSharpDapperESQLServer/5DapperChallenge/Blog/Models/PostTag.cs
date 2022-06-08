using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[PostTag]")]
    public class PostTag
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
    }
}
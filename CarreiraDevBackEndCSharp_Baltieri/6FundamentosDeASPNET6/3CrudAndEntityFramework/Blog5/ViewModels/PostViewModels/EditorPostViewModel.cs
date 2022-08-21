using System.ComponentModel.DataAnnotations;
using Blog.Models;

namespace Blog.ViewModels.PostViewModels
{
    public class EditorPostViewModel
    {
        [Required(ErrorMessage = "O título é obrigatório!")]
        [MaxLength(160)]
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public Category Category { get; set; }
        public User Author { get; set; } 

        public List<Tag> Tags { get; set; }
    }
}

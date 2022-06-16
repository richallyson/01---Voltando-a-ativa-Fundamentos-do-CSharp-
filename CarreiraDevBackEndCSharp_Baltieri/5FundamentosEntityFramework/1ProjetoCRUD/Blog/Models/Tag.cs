using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("Tag")]
    public class Tag
    {
        // O [Key] especifica que aquela propriedade é a chave primaria
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
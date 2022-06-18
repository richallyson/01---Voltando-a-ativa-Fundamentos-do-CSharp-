using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("Category")]
    public class Category
    {
        // Essa notação informa que essa propriedade abaixo é a chave primaria
        [Key]
        // Essa notação informa que a Id é gerada no banco de dados através de um Identity
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Marca o campo como NOT NULL. Quando o nosso campo for gerado por migração, ele já marca pra gente esse campo como not null
        [Required]
        // Define o tamanho minimo do campo. Mesmo não existindo essa condição no banco, ele já vai fazer essa verificação pra gente em tempo de compilação
        [MinLength(3)]
        // Define o tamanho máximo do campo
        // Se você não explicitar o MaxLength, ele vai criar um NVARCHAR MAX
        [MaxLength(80)] // No nosso banco a gente fez um NVARCHAR(80), então tem que ser exatamente igual o do banco
        // Especificando que a coluna Name é um NVARCHAR
        // Aqui não precisamos fazer um NVARCHAR(length), isso já vai ser tratado pra gente no MaxLength
        // Você só coloca o tipo de dado que quer aqui
        [Column("Name", TypeName = "NVARCHAR")]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        [Column("Slug", TypeName = "VARCHAR")]
        public string Slug { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Como eu ligo essa notação ao id do objeto categoria? 
        // Antes de tudo, siga esse padrão mostrado, pois caso não seja seguido não vai funcionar
        // Bem, como dito, por padrão, o ForeignKey vai separar o atributo da notação em duas partes
        // Ele vai pegar a primeira palavra com letra maiuscula e entender ela como sendo a CLASSE
        // Depois vai pegar a segunda palavra com letra maiuscula e entender ela como a PROPRIEDADE daquela CLASSE 
        // Ele vai fazer essa separação pra gente a partir desse padrão que está sendo imposto abaixo
        // E bem, com a notação criada, ele vai buscar na classe classe Category a propriedade Id
        // Outra coisa vital é que essa classe TEM que estar mapeada, caso contrário vai acontecer um erro
        // Além disso, a classe tem que esta dentro do DataContext, com o seu DbSet especifico
        // Ou seja, ela precisa ser criada como propriedade da classe DataContext como um DbSet<Classe>
        // Novamente, se você não passar ela pro DataContext, vai ocorrer um erro
        // E bem, muitas das vezes a gente não vai precisar só do Id da categoria, a gente vai querer carregar mais informações...
        // como por exemplo o seu nome ou slug. 
        // E para isso existe algo chamado de PROPRIEDADE DE NAVEGAÇÃO, que é algo provido pelo nosso EF
        // Basicamente é como se a gente fosse fazer um inner join dentro do SQL Server. A gente sabe que é muito mais performatico...
        // fazer um inner join do quê duas queries. 
        // E para isso, basta você criar uma propriedade abaixo da chave estrangeira do tipo que a chave estrangeira referência
        // Ao fazer isso, o EF já vai entender que aquela propriedade é uma PROPRIEDADE DE NAVEGAÇÃO
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Eu disse lá acima que você deve criar uma propriedade de acordo com a propriedade que a chave estrangeira referência
        // E é exatamente isso mesmo. Um Author também é um usuário do Blog. Apesar da nomenclatura ser diferente, um autor ainda é um usuário
        // Então no fim vai funcionar do mesmo jeito. O que não se pode fazer é instanciar uma propriedade de uma classe que não tem nada a ver com o contexto
        // Como por exemplo, criar uma propriedade Tag como PROPRIEDADE DE NAVEGAÇÃO para um Usuário. Vai acontecer um erro
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
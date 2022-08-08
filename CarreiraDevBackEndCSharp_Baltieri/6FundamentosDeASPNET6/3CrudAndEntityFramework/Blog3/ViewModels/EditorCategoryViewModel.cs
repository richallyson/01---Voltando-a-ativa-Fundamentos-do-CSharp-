using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    // = Validações = Primeiro lê tudo que ta escrito no CategoryController e depois vem pra cá
    // Uma grande vantagem da gente trabalhar com ViewModels é que a gente tem validações separadas das validações dos nossos Models
    // Então nos modelos a gente sabe que tudo a gente coloca nos modelos, ele ta refletindo diretamente os dados nossa aplicação
    // E nem sempre isso é sadio, nem sempre isso é legal. Por exemplo, se a gente quisesse ter uma validação que é exclusiva para tela, a gente não conseguiria ter direto nos modelos
    // Então os ViewModels separam isso pra gente, abstraem essas validações na tela pra gente
    // E como a gente aplica validação no ASP.NET?
    // Existem muitas formas de se fazer isso, mas como a gente ta trabalhando em um cenário Data-Driven (Orientado a dados), é melhor usar as anotações aqui do próprio ASP.NET
    // E anotações ou DataAnnotations a gente já conhece bem pois trabalhamos bastante com elas nos cursos de Dapper e EF
    // E a gente começa fazendo isso botando um [Required] em Name dizendo que ele é requerido toda vez que a gente for criar ou atualizar uma categoria
    // É literalmente o que a gente fez nos cursos anteriores, então eu não vou explicar novamente sobre, pois é algo muito fácil de se fazer
    // E vamos supor que você queira que o nome seja requerido apenas na hora de criar mas não atualizar, o que fazer? Ai tem que criar outra classe só pro update
    // Se você for agora no postman e tentar criar ou atualizar uma categoria, e passar o nome e slug em branco ou um preenchido e outro em braco, o postman vai retornar um erro
    // A validação vai acontecer automaticamente pelo ASP.NET. E isso tudo acontece dentro do nosso controller
    // Antigamente, as validações dentro dos controllers eram feitas através da chamada do ModelState
    // O ModelState é chamado toda vez que a gente passa um modelo como parametro dntro de alguma ação dentro do nosso controller
    // E o ModelState verifica se o nosso modelo ta válido ou não, baseado nas anotações que a gente faz no nosso modelo
    // Dentro do ModelState a gente tem uma propriedade chamada IsValid. E antigamente a galera fazia um if para verificar se tudo estava validado direitin: if(!ModelState.IsValid) return BadRequest()
    // O ASP.NET já faz tudo isso por padrão pra gente, sem a gente ter que ficar chamando o ModelState para validar os campos
    // Porém, se a qualquer momento você quiser fazer essa validação do ModelState, pode fazer, que não tem problema
    // Inclusive, tem um EXEMPLO disso no nosso Post de Category
    // Outra coisa que a gente pode fazer é passar a mensagem de erro diretamente na anotação. O ASP.NET tem uma mensagem padrão em inglês, mas provavelmente a gente vai ta trabalhando com sistemas em pt-br, então vale a pena passar essa mensagem em pt-br
    // E claro que a gente tem mais validações para se fazer, como o tamanho da string e etc. Todas as validações são cumulativas
    // Ou seja, eu criei uma categoria no banco, e passei um nome pra ela, isso fez ela passar na validação do required, porém, a string é maior do que o máximo estipulado, sendo assim, vai retornar um erro, pois não satisfez todas as validações
    // E existem DIVEEEEEERSAS validações, das quais a gente vai ver mais durante o curso. Tem validação pra saber se aquele campo realmente é um email, de range de valor, entre n outras 
    // E claro, que a gente também consegue criar validações costumizadas
    // Se tu rodar no postman agora, pra dar erro, não passando nada na string, ele vai retornar essas duas mensagens de erro que a gente botou, bonitin
    // E essa é forma mais simples, direta e rápida que a gente tem de fazer validações dentro das nossas APIs pelo ASP.NET

    public class EditorCategoryViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório!")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 40 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O slug é obrigatório")]
        public string Slug { get; set; }
    }
}

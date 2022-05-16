namespace Payments
{

    // Uma classe PARTIAL pode ser segmentada em mais de um arquivo
    // Ou seja, a classe vai ser dividida em diversos arquivos para algum uso
    // Um bom exemplo é na questão de validação
    // Um arquivo que faz validações dentro daquele contexto, mas que em outro contexto faz validações diferentes
    // Ou seja, se você fosse criar uma classe única pra validação, seu código seria gigantesco, ficando muito ruim de se trabalhar depois de um tempo
    // Não substitui a herança. Em alguns casos a herança é melhor, assim como em outros o PARTIAL é melhor
    // No arquivo CreditCardPayment eu usei um PARTIAL tbm
    // Recomendo fazer uma instancia da classe na main e chamar a propriedade criada em cada arquivo
    public partial class Payment
    {
        public int PropriedadeA { get; set; }
    }
}
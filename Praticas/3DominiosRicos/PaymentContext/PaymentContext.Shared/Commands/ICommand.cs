namespace PaymentContext.Shared.Commands
{
    // CQRS = Command Querry Responsibility Segregation
    // Commando é input  (escrita), e Querry é leitura
    public interface ICommand
    {
        void Validate();
    }
}
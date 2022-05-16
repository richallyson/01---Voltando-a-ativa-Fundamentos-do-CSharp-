using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    // Commands nada mais são do que a junção de todas as informações que a gente precisa pra criar uma subscription
    // No caso nesse contexto de subscription
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        // Essas propriedades n precisam ser privadas, pois esse objeto é apenas um objeto de transporte. Passagem de uma camada para outra
        // Fail Fast Validation
        // Toda vez que entrar algo na sua API, vai entrar um JSON (API trabalha com JSON de entrada e JSON de saída)
        // Entrou um JSON, e ele vai converter o JSON pelo objeto, no caso esse command que criamos
        // Em seguida vamos chamar o Validate, e verificar se ele está válido
        // Feito isso, se meu comando estiver inválido, eu já retorno um erro, e não prossigo com a requisição 
        // E para que serve? Para poupar requisições. Se bater aqui e não for validade, já vai encerrar aqui mesmo, impedido que continue chamando
        // requisições, e ganhando muito mais tempo
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }

        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }

        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Owner { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerDocument { get; set; }
        public EDocumentType OwnerDocumentType { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos três caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos três caracteres")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome só pode ter até 40 caracteres")
                .HasMaxLen(LastName, 40, "Name.LastName", "Sobrenome só pode ter até 40 caracteres")
            );
        }
    }
}

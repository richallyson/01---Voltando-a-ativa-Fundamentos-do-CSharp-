using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(
            string cardHolderName,
            string cardNumber,
            string lastTrasactionNumber,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string owner,
            Document document,
            Adress adress,
            Email email)
        : base(paidDate, expireDate, total, totalPaid, owner, document, adress, email)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTrasactionNumber = lastTrasactionNumber;
        }

        // Sempre use getway pra pegar as infos do cartão. Não podem ser armazenadas
        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTrasactionNumber { get; private set; }
    }
}
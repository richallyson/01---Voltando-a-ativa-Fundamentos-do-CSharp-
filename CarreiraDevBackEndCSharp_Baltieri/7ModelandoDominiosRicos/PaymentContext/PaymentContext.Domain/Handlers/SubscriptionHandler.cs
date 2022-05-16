using System;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    // Para adicionar outro Command pro handler, basta botar outro IHandler<>, dps do ultimo, passando como tipo o Command que você quer
    // E basicamente o código vai ficar o mesmo, mudando apenas o que é necessário para aquele tipo de pagamento
    public class SubscriptionHandler :
    Notifiable,
    IHandler<CreateBoletoSubscriptionCommand>,
    IHandler<CreatePaypalSubscriptionCommand>,
    IHandler<CreateCreditCardSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {

            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");
            }

            // Verificar se Document já está cadastrado
            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso.");

            // Verificar se Email já está cadastrado
            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "Este Email já está em uso.");

            // Gerar VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var adress = new Adress(command.State, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar Entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(
                command.BarCode,
                command.BoletoNumber,
                command.PaidDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid,
                command.Owner,
                new Document(command.OwnerDocument, command.OwnerDocumentType),
                new Adress(command.State, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode),
                new Email(command.Email)
            );

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupar validações
            AddNotifications(name, document, email, adress, student, subscription, payment);

            // Checar notificações
            if (Invalid)
                return new CommandResult(true, "Assinatura realizada com sucesso");

            // Salvar informações
            _repository.CreateSubscription(student);

            // Enviar email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Adress, "Bem vindo!", "Sua assinatura foi criada. Bom curso!");

            // Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreatePaypalSubscriptionCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");
            }

            // Verificar se Document já está cadastrado
            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso.");

            // Verificar se Email já está cadastrado
            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "Este Email já está em uso.");

            // Gerar VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var adress = new Adress(command.State, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar Entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PaypalPayment(
                command.TransactionCode,
                command.PaidDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid,
                command.Owner,
                new Document(command.OwnerDocument, command.OwnerDocumentType),
                new Adress(command.State, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode),
                new Email(command.Email)
            );

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupar validações
            AddNotifications(name, document, email, adress, student, subscription, payment);

            // Checar notificações
            if (Invalid)
                return new CommandResult(true, "Assinatura realizada com sucesso");

            // Salvar informações
            _repository.CreateSubscription(student);

            // Enviar email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Adress, "Bem vindo!", "Sua assinatura foi criada. Bom curso!");

            // Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");
            }

            // Verificar se Document já está cadastrado
            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso.");

            // Verificar se Email já está cadastrado
            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "Este Email já está em uso.");

            // Gerar VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var adress = new Adress(command.State, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar Entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCardPayment(
                command.CardHolderName,
                command.CardNumber,
                command.LastTrasactionNumber,
                command.PaidDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid,
                command.Owner,
                new Document(command.OwnerDocument, command.OwnerDocumentType),
                new Adress(command.State, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode),
                new Email(command.Email)
            );

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupar validações
            AddNotifications(name, document, email, adress, student, subscription, payment);

            // Checar notificações
            if (Invalid)
                return new CommandResult(true, "Assinatura realizada com sucesso");

            // Salvar informações
            _repository.CreateSubscription(student);

            // Enviar email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Adress, "Bem vindo!", "Sua assinatura foi criada. Bom curso!");

            // Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}
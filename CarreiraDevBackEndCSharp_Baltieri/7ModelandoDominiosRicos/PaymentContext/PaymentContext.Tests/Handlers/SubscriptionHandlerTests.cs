using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Shang";
            command.LastName = "Tsung";
            command.Document = "99999999999";
            command.Email = "mk@tournament.com";

            command.BarCode = "123456789456";
            command.BoletoNumber = "123123132121";

            command.PaymentNumber = "446546545";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 100;
            command.TotalPaid = 100;
            command.Owner = command.FirstName;
            command.OwnerEmail = command.Email;
            command.OwnerDocument = command.Document;
            command.OwnerDocumentType = EDocumentType.CPF;
            command.Street = "The Krypt";
            command.Number = "777";
            command.Neighborhood = "Goro`s Lair";
            command.City = "Chicago";
            command.State = "Unknown";
            command.Country = "NetherRealm";
            command.ZipCode = "1245878";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}

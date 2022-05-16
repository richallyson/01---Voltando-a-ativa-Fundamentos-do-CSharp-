using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Adress _adress;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Klint", "Westwood");
            _document = new Document("48756987487", EDocumentType.CPF);
            _email = new Email("klint@gmail.com");
            _adress = new Adress("Rua Carlos Maia", "70", "Pote Seco", "West", "OldTown", "Brasil", "8945000");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PaypalPayment("1245966", DateTime.Now, DateTime.Now.AddDays(30), 100, 100, "Klint Westwood", _document, _adress, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        public void ShouldReturnSucessWhenAddSubscription()
        {
            var payment = new PaypalPayment("1245966", DateTime.Now, DateTime.Now.AddDays(30), 100, 100, "Klint Westwood", _document, _adress, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}

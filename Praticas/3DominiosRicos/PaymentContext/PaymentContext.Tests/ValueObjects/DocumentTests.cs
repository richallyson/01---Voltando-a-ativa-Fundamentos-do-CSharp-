using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class DocumentTests
    {
        // Metodologia Red, Green e Refactor
        // Primeira coisa que a gente vai fazer é escrever os casos de teste e fazer eles falharem
        // Depois a gente vai fazer esses testes passarem, e isso vai deixar tudo meio bagunçado
        // E depois a gente vai refatorar o código, pra ajeitar essa bagunça
        // Ou seja, deixa tudo vermelho, com erros, dps concerta tudo, deixa verde, e depois refatora pra arrumar a bagunça
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenCNPJIsValid()
        {
            var doc = new Document("74501020000182", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("24599413578")]
        [DataRow("89006061077")]
        [DataRow("89006061077")]
        public void ShouldReturnSucessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Enums;
using Payment.Domain.ValuesObjects;

namespace Payment.Tests
{
    [TestClass]
    public class DocumentTests
    {
        //red, gree, refactor
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }
        [TestMethod]
        public void ShouldReturnSucessWhenCNPJIsInvalid()
        {
            var doc = new Document("12345678911111", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("18915396049")]
        [DataRow("92421680093")]
        [DataRow("45032916021")]
        public void ShouldReturnErrorWhenCPFInvalid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenCPFInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

    }
}

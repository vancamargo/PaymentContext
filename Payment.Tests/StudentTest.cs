using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Entities;
using Payment.Domain.Enums;
using Payment.Domain.ValuesObjects;
using System;

namespace Payment.Tests
{
    [TestClass]
    public class StudentTest
    {

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscriptions()
        {
            var name = new Name("Bruce", "Wayne");
            var document = new Document("35111507795", EDocumentType.CPF);
            var email = new Email("barney@gmail.com");
            var adress = new Adress("rua 1", "1234", "Bairro legal", "Gothan", "Sp", "br", "13400000");
            var student = new Student(name, document, email);
            var subscription = new Subscription(null);
            var payment = new  PayPalPayment("123457",DateTime.Now, DateTime.Now.AddDays(5), 10, 10, adress, document, "Wayne", email);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            student.AddSubscription(subscription);
            Assert.IsTrue(student.Invalid);

         
        }

        public void ShouldReturnErrorWhenHadSubscriptionsHasNoPayment()
        {
            var name = new Name("Bruce", "Wayne");
            var document = new Document("35111507795", EDocumentType.CPF);
            var email = new Email("barney@gmail.com");
            var student = new Student(name, document, email);

            Assert.Fail();
        }

        [TestMethod]
        public void ShouldReturnSucessWhenHadNoActiveSubscriptions()
        {
            Assert.Fail();
        }

    }
}
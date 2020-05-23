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
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Adress _adress;
        private readonly Email _email;



        public StudentTest()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("35111507795", EDocumentType.CPF);
            _email = new Email("barney@gmail.com");
            _adress = new Adress("rua 1", "1234", "Bairro legal", "Gothan", "Sp", "br", "13400000");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
          
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscriptions()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("123457", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _adress, _document, "Wayne", _email);
            subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);
            

           
            Assert.IsTrue(_student.Invalid);

         
        }
        [TestMethod]
        public void ShouldReturnErrorWhenHadSubscriptionsHasNoPayment()
        {
            var subscription = new Subscription(null);
            _student.AddSubscription(subscription);
            
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenHadNoActiveSubscriptions()
        {

            var payment = new PayPalPayment("123457", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _adress, _document, "Wayne", _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

    }
}
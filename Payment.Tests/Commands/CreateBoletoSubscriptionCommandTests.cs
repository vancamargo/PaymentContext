
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Commands;
using Payment.Domain.Enums;
using Payment.Domain.ValuesObjects;

namespace Payment.Tests
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests
    {
        //red, gree, refactor
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";

            command.Validate();
            Assert.AreEqual(false, command.Valid);
        }

    }

}
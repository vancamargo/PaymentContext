using Payment.Domain.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string transactionCode, DateTime paidDate, DateTime expireDate, 
            decimal total, decimal totalPaid, Address address, Document document, string payer, Email email) :
            base(paidDate, expireDate, total, totalPaid, address, document, payer, email)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; set; }
    }
}

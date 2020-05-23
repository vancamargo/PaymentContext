using Payment.Domain.Enums;
using Payment.Domain.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        private DateTime paidDate;
        private DateTime expireDate;
        private decimal total;
        private decimal totalPaid;
        private string payer;
        private (string PayerDocument, EDocumentType PayerDocumentType) p;
        private Adress adress;
        private Email email;

        public BoletoPayment(string barcode, string boletoNumber, DateTime paidDate, DateTime expireDate,
            decimal total, decimal totalPaid, Adress address, Document document, string payer, Email email) :
            base(paidDate, expireDate, total, totalPaid, address, document, payer, email)
        {
            Barcode = barcode;
            BoletoNumber = boletoNumber;
        }

        public BoletoPayment(string barcode, string boletoNumber, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, (string PayerDocument, EDocumentType PayerDocumentType) p, Adress adress, Email email)
        {
            Barcode = barcode;
            BoletoNumber = boletoNumber;
            this.paidDate = paidDate;
            this.expireDate = expireDate;
            this.total = total;
            this.totalPaid = totalPaid;
            this.payer = payer;
            this.p = p;
            this.adress = adress;
            this.email = email;
        }

        public string Barcode { get;private set; }
        public string BoletoNumber { get;private set; }
    }
}

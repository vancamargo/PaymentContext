﻿using Payment.Domain.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string barcode, string boletoNumber, DateTime paidDate, DateTime expireDate,
            decimal total, decimal totalPaid, Adress address, Document document, string payer, Email email) :
            base(paidDate, expireDate, total, totalPaid, address, document, payer, email)
        {
            Barcode = barcode;
            BoletoNumber = boletoNumber;
        }

        public string Barcode { get;private set; }
        public string BoletoNumber { get;private set; }
    }
}

﻿using Flunt.Validations;
using Payment.Domain.ValuesObjects;
using Payment.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Entities
{
    public abstract class  Payment :Entity
    {
        protected Payment( DateTime paidDate, DateTime expireDate, 
            decimal total, decimal totalPaid, Adress address, Document document, string payer, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper() ;
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Address = address;
            Document = document;
            Payer = payer;
            Email = email;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(0, Total, "Payment.Total", "O total não pode ser zero")
                .IsGreaterOrEqualsThan(Total,  TotalPaid, "Payment.TotalPaid", "O valor pago é menor do que o valor do pagamento ")
                
                
                
                );
            
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public Adress Address { get; private set; }
        public Document Document { get; private set; }
        public string Payer { get; private set; }
        public Email Email { get; private set; }
    }
    
}

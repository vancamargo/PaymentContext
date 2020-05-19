using Flunt.Validations;
using Payment.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.ValuesObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Adress = address;
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Adress, "Email.Adress", "E-mail inválido")
                );
        }

        public string Adress { get; private set; }
      
    }
}

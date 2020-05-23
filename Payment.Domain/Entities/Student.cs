using Flunt.Validations;
using Payment.Domain.ValuesObjects;
using Payment.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;


namespace Payment.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
          
        }

        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Adress Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            //Se já tiver uma assinatura ativa, cancela
            // Cancela todas as outras assinaturas, e coloca esta como principal

            var hasSubscritionActive = false;
            foreach (var sub in _subscriptions)
            {
                if (sub.Active)
                    hasSubscritionActive = true;
            }
            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscritionActive, "Student.Subscritions", "Você já tem uma assinatura ativa")
                .AreEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "Esta assinatura nao possui pagamento")
                ) ;

            //if (hasSubscritionActive)
            //    AddNotification("Student.Subscritions", "Você já tem uma assinatura ativa");
        }
      


    }
}

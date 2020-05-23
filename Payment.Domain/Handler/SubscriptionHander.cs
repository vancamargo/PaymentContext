using Flunt.Notifications;
using Flunt.Validations;
using Payment.Domain.Commands;
using Payment.Domain.Entities;
using Payment.Domain.Enums;
using Payment.Domain.Repositories;
using Payment.Domain.Services;
using Payment.Domain.ValuesObjects;
using Payment.Shared.Commands;
using Payment.Shared.Handler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Handler
{
    public class SubscriptionHander : Notifiable,
        IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHander(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public IComandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fail Fast validation

            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");
            }

            if (_repository.DocumentExist(command.Document))
                AddNotification("Document", "Este cpf já esta em uso");

            if (_repository.EmailtExist(command.Email))
                AddNotification("Document", "Este e-mail já esta em uso");

            //gerar as vo
             var name = new Name(command.FirstName, "Wayne");
             var document = new Document(command.Document, EDocumentType.CPF);
             var email = new Email(command.Email);
             var adress = new Adress(command.Street, command.Number, command.Neighborhood, command.City, command.Neighborhood, command.Country, command.ZipCode);

            //gerar as entidades

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.Barcode,
                command.BoletoNumber,
                command.PaidDate,
                command.ExpireDate,
                command.Total, 
                command.TotalPaid,
                command.Payer,
                (command.PayerDocument,
                command.PayerDocumentType), adress, email
                );
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            AddNotifications(name, document, email, adress, student, payment);

            _repository.CreateSubscriptions(student);

            //Verificar se documento já esta cadastrado

            //Verificar se email ja esta cadastrado 
            //Gerar os VO

            //Aplicar as Validações 

            //Enviar e-mail de boas vindas
            _emailService.Send(student.Name.FirstName, student.Email.Adress, "bem vindo", "sua assinatura foi criada");

            return new CommandResult(true, "assinatura realizadada com sucesso");
        }
    }
}

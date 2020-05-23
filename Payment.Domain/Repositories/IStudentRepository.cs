using Payment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Repositories
{
    public interface IStudentRepository

    {
        bool DocumentExist(string document);
        bool EmailtExist(string document);
        void CreateSubscriptions(Student student);
    }
}

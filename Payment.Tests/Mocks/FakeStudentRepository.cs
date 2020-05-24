using Payment.Domain.Repositories;
using Payment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscriptions(Student student)
        {
           
        }

        public bool DocumentExist(string document)
        {
            if (document == "99999999")
                return true;
            return false;
        }

        public bool EmailtExist(string email)
        {
            if (email == "helo@gmail.com")
                return true;
            return false;
        }
    }
    
    
}

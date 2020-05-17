using Payment.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Tests.Entities
{
    public class StudentTests
    {
        public void TesteMethod1()
        {
            var student = new Student("Vanessa", "Camargo", "333.555.666", "vanessacamargo@gmail.com");
        }
    }
}

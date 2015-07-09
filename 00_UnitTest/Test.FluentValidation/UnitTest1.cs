using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentValidation;

namespace Test.FluentValidation
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testObj=new Customer(){Id=1,Surname="2"};
            var result=new CustomerValidator().Validate(testObj);
            Assert.AreEqual(true, result.IsValid);
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public decimal Discount { get; set; }
        public string Address { get; set; }
    }

    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Id).NotEqual(0);
            RuleFor(customer => customer.Surname).NotNull();
        }
    }
}

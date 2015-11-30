using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTheMilk.Controllers;
using NUnit.Framework;


namespace ConsoleVerification
{
    class CreateTaskTests : AssertionHelper
    {   
        [Test]
        public void DescriptionAndNoDueDate()
        {
            var input = "Pick up the groceries";

            var task = new Task(input, default(DateTime));

            Expect(task.Description, Is.EqualTo(input));
            Assert.AreEqual(null, task.DueDate);
        }
    }
}

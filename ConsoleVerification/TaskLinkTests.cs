using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTheMilk.Controllers;
using NUnit.Framework;

namespace ConsoleVerification
{
    class TaskLinkTests : AssertionHelper
    {
        [Test]
        public void CreateTask_DescriptionWithALink_SetLink()
        {

            var input = "test http://www.google.com";

            var task = new Task(input, default(DateTime));

            Expect(task.Link, Is.EqualTo("http://www.google.com"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTheMilk.Controllers;

namespace ConsoleVerification
{
    internal class Program
    {
        static void Main(string[] args)
        {


            TestMayDueDateDoesNotWrapYear();
            TestMayDueDateDoesWrapYear();

            Console.ReadLine();


        }

        private static void TestMayDueDateDoesWrapYear()
        {
            var input = "Pick up the groceries may 5 - as of 2015-05-31";           
            Console.WriteLine("Scenario: " + input);
            var today = new DateTime(2015, 5, 31);

            var task = new Task(input, today);

            var dueDateShouldBe = new DateTime(2016, 5, 5);

            var success = dueDateShouldBe == task.DueDate;
            var failureMessage = "Due Date: " + task.DueDate + " should be " + dueDateShouldBe;
            PrintOutcome(success, failureMessage);
        }

        private static void TestMayDueDateDoesNotWrapYear()
        {
            var input = "Pick up the groceries may 5 - as of 2015-05-04";
            Console.WriteLine("Scenario: " + input);
            var today = new DateTime(2015, 5, 4);

            var task = new Task(input, today);

            var dueDateShouldBe = new DateTime(2015, 5, 5);

            var success = dueDateShouldBe == task.DueDate;
            var failureMessage = "Due Date: " + task.DueDate + " should be " + dueDateShouldBe;
            PrintOutcome(success, failureMessage);
        }

       
        public static void PrintOutcome(bool success, string failureMessage)
        {
            if (success)
            {
                Console.WriteLine(success);
            }
            else
            {
                Console.WriteLine("ERROR: ");
                Console.WriteLine(failureMessage);
            }

            Console.WriteLine();

        }

    }
}

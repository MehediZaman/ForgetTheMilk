using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace ForgetTheMilk.Controllers
{
    public class TaskController : Controller
    {
        public ActionResult Index()
        {
            return View(Tasks);
        }

        public static readonly List<Task> Tasks = new List<Task>();

        [HttpPost]
        public ActionResult Add(string task)
        {
            var taskItem = new Task(task, DateTime.Today);
           
            Tasks.Add(taskItem);
            return RedirectToAction("Index");
        }
    }

    public class Task
    {
      
        public Task(string task, DateTime today)
        {
            Description = task;
            var dueDatePattern = new Regex(@"may\s(\d)");
            var hasDueDate = dueDatePattern.IsMatch(task);
            if (hasDueDate)
            {
                var dueDate = dueDatePattern.Match(task);
                var day = Convert.ToInt32(dueDate.Groups[1].Value);
                DueDate = new DateTime(today.Year, 5, day);
                
                if (DueDate < today)
                {
                    DueDate = DueDate.Value.AddYears(1);
                }
            }
        }

        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
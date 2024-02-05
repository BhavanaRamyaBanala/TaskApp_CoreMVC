using Microsoft.AspNetCore.Mvc;
using CoreMVC_TaskWebApp.Models;

namespace CoreMVC_TaskWebApp.Controllers
{
    public class TasksController : Controller
    {
        static List<Tasks> tasks = new List<Tasks>() {
            new Tasks{ Id=1,Title="San",Description="Editor",DueDate=new DateTime(day: 12,month:05,year:2020)},
            new Tasks{ Id=2,Title="Han",Description="Actor",DueDate=new DateTime(day: 25,month:11,year:2019)},
            new Tasks{ Id=3,Title="Kan",Description="Director",DueDate=new DateTime(day: 06,month:03,year:2023)}
        };
        public IActionResult Index() { 
        
            return View(tasks);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Tasks());
        }
        [HttpPost]
        public IActionResult Create(Tasks t) {
            if (t != null)
            {
                if (ModelState.IsValid)
                {
                    tasks.Add(t);
                    return RedirectToAction("Index");
                }
            }
            return View(t);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Tasks t = tasks.SingleOrDefault(task => task.Id == Id);
            return View(t);
        }

        [HttpPost]
        public IActionResult Edit(Tasks updatedTask)
        {
            if (updatedTask != null)
            {
                if (ModelState.IsValid)
                {
                    Tasks existingTask = tasks.SingleOrDefault(task => task.Id == updatedTask.Id);

                    if (existingTask != null)
                    {
                        existingTask.Title = updatedTask.Title;
                        existingTask.Description = updatedTask.Description;
                        existingTask.DueDate = updatedTask.DueDate;

                        return RedirectToAction("Index");
                    }
                }
            }

            return View(updatedTask);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Tasks t = tasks.SingleOrDefault(t => t.Id == Id);
            return View(t);
        }
        [HttpPost]
        public IActionResult Delete(int? Id)
        {
            Tasks t= tasks.SingleOrDefault(t=> t.Id == Id);
            if (t != null)
            {
                tasks.Remove(t);
            }
            return RedirectToAction("Index");
        }
    }
}

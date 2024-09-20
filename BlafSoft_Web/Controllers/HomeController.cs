using BlafSoft_Task;
using BlafSoft_Web.Models;
using BlafSoft_Web.Services.Implementations;
using BlafSoft_Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlafSoft_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InterfaceTaskService _service;
        public readonly IConfiguration _configuration;
        private readonly JWTGenerator jwt;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _service = new TaskService();
            _configuration = configuration;
            jwt = new JWTGenerator(_configuration);
        }

        public IActionResult Index()
        {
            List<TaskT> tasks = _service.GetAll();
            return View(tasks);
        }

        public IActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTaskSubmit(TaskT task)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _service.Create(_service.GetAll(), task);
            return RedirectToAction("Index");

        }
        public IActionResult Update(int id)
        {
            TaskT task = _service.GetById(id);
            return View(task);
        }

        [HttpPost]
        public IActionResult UpdateSubmit(TaskT task)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _service.Update(task.Id, task, _service.GetAll());
            return RedirectToAction("Index");

        }

        public IActionResult DeleteSubmit(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _service.Delete(_service.GetAll(), id);
            return RedirectToAction("Index");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

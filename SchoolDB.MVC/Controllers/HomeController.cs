using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolDB.Logic.Interfaces;
using SchoolDB.Model.Models;
using SchoolDB.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDB.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, IGradeLogic logic, IClassLogic _CLogic, IStudentLogic _SLogic)
        {
            _logger = logger;
            this._Logic = logic;
            this._CLogic = _CLogic;
            this._SLogic=_SLogic;
        }

        IGradeLogic _Logic;
        IClassLogic _CLogic;
        IStudentLogic _SLogic;
        public IActionResult ListAllGrades()
        {
            return View(this._Logic.ReadAll());
        }

        [HttpGet]
        public IActionResult EditGrade(int id)
        {
            return View(_Logic.Read(id));
        }

        [HttpPost]
        public IActionResult EditGrade(Grade item)
        {
            _Logic.Update(item);
            return RedirectToAction(nameof(ListAllGrades));
        }

        [HttpGet]
        public IActionResult DeleteGrade(int id)
        {
            return View(_Logic.Read(id));
        }

        [HttpPost]
        public IActionResult DeleteGrade(Grade item)
        {
            _Logic.Delete(item.Id);
            return RedirectToAction(nameof(ListAllGrades));
        }

        [HttpPost]
        public IActionResult Create(Grade item)
        {
            _Logic.Create(item);
            return RedirectToAction(nameof(ListAllGrades));
        }


        //Class
        [HttpGet]
        public IActionResult ClassReadAll()
        {
            return View(_CLogic.ReadAll());
        }

        [HttpGet]
        public IActionResult ClassAllMember(int id)
        {
            return View(_CLogic.Read(id));
        }

        //Tanulo
        [HttpGet]
        public IActionResult StudentAvgMonth()
        {
            return View(this._SLogic.ReadAll());
        }


        //Avg jegyek
        [HttpGet]
        public IActionResult Choose(int id)
        {
            return View(_SLogic.Read(id));
        }

        [HttpPost]
        public IActionResult Choose(Student item,int month)
        {
            return View("GetResults", _Logic.StudentSAvg(item, month));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pua_UserManagement.Context;
using Pua_UserManagement.Models;

namespace Pua_UserManagement.Controllers    
{
    public class UserController : Controller
    {
        private readonly MyDBContext _dBContext;

        public UserController(MyDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public IActionResult Index()
        {
            List<Person> person = _dBContext.People.Include(p => p.User).ToList();
            return View(person);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateProcess(Person person)
        {
            if (!ModelState.IsValid) return View(person);
            person.DateCreated = DateTime.Now;

            _dBContext.People.Add(person);
            _dBContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult UpdatePartial(int id)
        {
            Person? person = _dBContext.People.Include(a=>a.User).FirstOrDefault(p => p.Id == id);
            return PartialView();
        }
    }
}

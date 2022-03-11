using SimpleFormExample.Entities;
using SimpleFormExample.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SimpleFormExample.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var listado = await GetUsers();
            return View(listado);
        }
        [HttpGet]
        public async Task<JsonResult> GetUsersAsync()
        {
            var listado = await GetUsers();
            return Json(new { data = listado }, JsonRequestBehavior.AllowGet);
        }
        private async Task<List<UserList>> GetUsers()
        {
            var listado = new List<UserList>();
            using (AppDbContext db = new AppDbContext())
            {
                listado = await db.Users.Select(s => new UserList
                {
                    Id = s.Id,
                    Nombre = s.Name,
                    Pais = s.Country.Name,
                    Tipo = s.Type
                }).ToListAsync();
            }
            return listado;
        }
        [HttpGet]
        public async Task<JsonResult> GetCountriesAsync()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var listado = await db.Countries.Select(s => new Catalog { Id = s.CountryId, Nombre = s.Name }).ToListAsync();
                return Json(new { data = listado }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Save(UserDTO data)
        {
            if (ModelState.IsValid)
            {
                using (AppDbContext db = new AppDbContext())
                {
                    var user = new Users { Name = data.nombre, Type = data.tipo, CountryId = data.pais };
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Json(new { data = user.Id }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { data = 0 }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Blogify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blogify.Controllers
{
    public class AdminController : Controller
    {
        private readonly BlogifyContext context;

        public AdminController(BlogifyContext context)
        {
            this.context=context;
        }

        public IActionResult Index()
        {
            return View(context);
        }

        public IActionResult URemove(int id)
        {
            User u = context.Users.FirstOrDefault(x=>x.Id == id);
            foreach (var item in context.Blogs.ToList())
            {
                if (item.WriterId==id)
                {
                    context.Blogs.Remove(item);
                }
            }
            context.Users.Remove(u);
            context.SaveChanges();
            return RedirectToAction("Users","Admin");
        }

        public IActionResult Okundu(int id)
        {
            var Bil = context.Bildiris.FirstOrDefault(x=>x.Id ==id);
            Bil.Okundumu=true;
            context.Bildiris.Update(Bil);
            context.SaveChanges();
            return RedirectToAction("OS", "Admin");
        }

        public IActionResult Bak(int id)
        {
            var Bil = context.Bildiris.FirstOrDefault(x=>x.Id ==id);
            return View(Bil);
        }

        public IActionResult BRemove(int id)
        {
            Blog u = context.Blogs.FirstOrDefault(x=>x.Id == id);
            context.Blogs.Remove(u);
            context.SaveChanges();
            return RedirectToAction("Blogs","Admin");
        }

        public IActionResult Users()
        {
            return View(context.Users.ToList());
        }

        public IActionResult Blogs()
        {
            return View(context.Blogs.ToList());
        }

        public IActionResult OS()
        {
            return View(context.Bildiris.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
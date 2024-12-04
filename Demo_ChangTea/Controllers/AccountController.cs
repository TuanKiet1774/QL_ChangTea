using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_ChangTea.Models;

namespace Demo_ChangTea.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View(new Login()); // Initialize with an empty ViewModel
        }

        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                // Add your login logic here (authentication logic)

                if (model.Username == "admin" && model.Password == "12345")
                {
                    // Successful login logic
                    Session["Username"] = model.Username;
                    return RedirectToAction("Index_Admin", "Mons");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model); // Return the model with errors if validation fails
        }

        public ActionResult Login_NV()
        {
            return View(new Login()); // Initialize with an empty ViewModel
        }

        [HttpPost]
        public ActionResult Login_NV(Login model)
        {
            if (ModelState.IsValid)
            {
                // Add your login logic here (authentication logic)

                if (model.Username == "admin" && model.Password == "12345")
                {
                    // Successful login logic
                    Session["Username"] = model.Username;
                    return RedirectToAction("Index", "NhanViens");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model); // Return the model with errors if validation fails
        }

        public ActionResult Login_Kho()
        {
            return View(new Login()); // Initialize with an empty ViewModel
        }

        [HttpPost]
        public ActionResult Login_Kho(Login model)
        {
            if (ModelState.IsValid)
            {
                // Add your login logic here (authentication logic)

                if (model.Username == "admin" && model.Password == "12345")
                {
                    // Successful login logic
                    Session["Username"] = model.Username;
                    return RedirectToAction("Index", "NguyenLieux");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model); // Return the model with errors if validation fails
        }

        public ActionResult Login_DoanhThu()
        {
            return View(new Login()); // Initialize with an empty ViewModel
        }

        [HttpPost]
        public ActionResult Login_DoanhThu(Login model)
        {
            if (ModelState.IsValid)
            {
                // Add your login logic here (authentication logic)

                if (model.Username == "admin" && model.Password == "12345")
                {
                    // Successful login logic
                    Session["Username"] = model.Username;
                    return RedirectToAction("DoanhThu", "HoaDons");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model); // Return the model with errors if validation fails
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

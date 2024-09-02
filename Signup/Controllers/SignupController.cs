using Signup.Models;
using Signup.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Signup.Controllers
{
    public class SignupController : Controller
    {

        // GET: Signup/Details/5
        public ActionResult GetUser()
        {
            UserRepository userRepo=new UserRepository();
            ModelState.Clear();
            return View(userRepo.GetUser());
        }

        // GET: Signup/Create
        public ActionResult AddUser()
        {
            return View();
        }

        // POST: Signup/Create
        [HttpPost]
        public ActionResult AddUser(SignupModel User)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserRepository userRepo = new UserRepository();
                    if (userRepo.AddUser(User))
                    {
                        ViewBag.Message="User details added successfully";
                    }
                }
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Signup/Edit/5
        public ActionResult UpdateUser(int id)
        {
            UserRepository UserRepo= new UserRepository();
            return View(UserRepo.GetUser().Find(User => User.UserId == id));
        }

        // POST: Signup/Edit/5
        [HttpPost]
        public ActionResult UpdateUser(int id, SignupModel obj)
        {
            try
            {
                UserRepository userRepo = new UserRepository();
                userRepo.UpdateUser(obj);

                return RedirectToAction("GetUser");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

      

        // POST: Signup/Delete/5
        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                  UserRepository userRepo=new UserRepository();
                if (userRepo.DeleteUser(id))
                {
                    ViewBag.AlertMsg="Employee details deleted";
                }

                return RedirectToAction("GetUser");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}

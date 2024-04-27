using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerAgnmt.Database;
using ZeroHungerAgnmt.Models;

namespace ZeroHungerAgnmt.Controllers
{
    public class ZeroHungerController : Controller
    {
        // GET: ZeroHunger

        [HttpGet]
        public ActionResult Login()
        {
            // Check if the session variable is already set
            if (Session["userid"] != null)
            {
                // Redirect to the corresponding profile page based on the AccountType
                int userId = Convert.ToInt32(Session["userid"]);
                var DBcontext = new Zero_HungerEntities2 { };
                var data = DBcontext.LoginInfoes.FirstOrDefault(LoginInfo => LoginInfo.Id == userId);

                if (data != null)
                {
                    if (data.AccountType == 1000)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (data.AccountType == 2000)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Employe");
                    }
                }
            }

            // If the session variable is not set, proceed to show the login page
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDto logProfile)
        {
            var DBcontext = new Zero_HungerEntities2 { };
            var data = DBcontext.LoginInfoes.FirstOrDefault(LoginInfo => LoginInfo.Email == logProfile.username && LoginInfo.Password == logProfile.password);

            if (data != null)
            {
                if (data.AccountType == 1000)
                {
                    Session["userid"] = data.Id;
                    return RedirectToAction("Index", "Admin");
                }
                else if (data.AccountType == 2000)
                {
                    var data2 = DBcontext.Resturents.FirstOrDefault(Resturent => Resturent.LId == data.Id);
                    Session["userid"] = data2.Id;
                    return RedirectToAction("Index");
                }
                else
                {
                    var data3 = DBcontext.Emplyoes.FirstOrDefault(Emplyo => Emplyo.LId == data.Id);
                    Session["userid"] = data3.Id;
                    return RedirectToAction("Index", "Employe");
                }
            }
            else
            {
                TempData["msg"] = "Invalid UserID";
            }

            return View(logProfile);
        }




        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUpDTO newUser)
        {
            if (ModelState.IsValid)
            {
                var loginData = new LoginInfo
                {
                    Email = newUser.Email,
                    Password = newUser.Password,
                    AccountType = newUser.AccountType
                };

                var DBcontext = new Zero_HungerEntities2 { };
                DBcontext.LoginInfoes.Add(loginData);
                DBcontext.SaveChanges();

                var restaurantData = new Resturent
                {
                    LId = loginData.Id,
                    RName = newUser.RName,
                    Address = newUser.Address,

                };

                DBcontext.Resturents.Add(restaurantData);
                DBcontext.SaveChanges();

                return RedirectToAction("LogIn");
            }
           
            return View(newUser);
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.ParselDTO newRequest)
        {
            if (ModelState.IsValid)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ParselDTO, Parsel>();
                });
                var mapper = new Mapper(config);
                var data = mapper.Map<Parsel>(newRequest);

                var DBcontext = new Zero_HungerEntities2 { };
                DBcontext.Parsels.Add(data);
                DBcontext.SaveChanges();

                return RedirectToAction("Parsel");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Parsel()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            var DBcontext = new Zero_HungerEntities2 { };
            var data2 = DBcontext.Parsels.Where(Parsel => Parsel.RId == userId).ToList();

            /*var allRequest = DBcontext.Parsels.ToList();*/
            return View(data2);
        }
        public ActionResult Logout()
        {
            // Clear the session
            Session.Clear();
            Session.Abandon();

            // Redirect to the login page or another page
            return RedirectToAction("Login", "ZeroHunger");
        }

    }
}
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerAgnmt.Database;
using ZeroHungerAgnmt.Models;
using System.Data.Entity;

namespace ZeroHungerAgnmt.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        [HttpGet]
        public ActionResult Index()
        {
            var DBcontext = new Zero_HungerEntities2();

            var viewModel = new parselempDTO
            {
                Parsels = (from p in DBcontext.Parsels
                           where p.Employee == null
                           join r in DBcontext.Resturents on p.RId equals r.Id
                           select new ShowParsel
                           {Id=p.Id,
                               RName = r.RName, // Assuming RName is a property in the Restaurants entity
                               FoodName = p.FoodName,
                               PreservationTime = p.PreservationTime,
                               TotalPacket = p.TotalPacket,
                               Status = p.Status,
                               
                           }).ToList(),
                Employees = DBcontext.Emplyoes.ToList()
            };

            return View(viewModel);


        }

        [HttpPost]
        public ActionResult Index(EmployeDTO assign)
        {
            var DBcontext = new Zero_HungerEntities2 { };
            var ParselID = DBcontext.Parsels.Find(assign.Id);
            if (ParselID != null)
            {
                ParselID.Employee = assign.Employee;
                DBcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("EmployeList");
        }
        public ActionResult Allparsel()
        {
            var DBcontext = new Zero_HungerEntities2 { };
            var allRequest = DBcontext.Parsels.ToList();
            return View(allRequest);
        }




        [HttpGet]
        public ActionResult EmployeeList()
        {
            var DBcontext = new Zero_HungerEntities2 { };
            var joinedData = (from emp in DBcontext.Emplyoes
                              join login in DBcontext.LoginInfoes on emp.LId equals login.Id
                              where login.AccountType == 3000
                              select new EmployeeViewModel
                              {
                                  EName = emp.EName,
                                  Address = emp.Address,
                                  Gender = emp.Gender,
                                  Id = emp.Id,
                                  Email = login.Email,
                              }).ToList();

            return View(joinedData);

        }

        [HttpGet]
        public ActionResult RegistarEmp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistarEmp(EmpDTO newStaff)
        {
            if (ModelState.IsValid)
            {
                /* var config = new MapperConfiguration(cfg => {
                     cfg.CreateMap<EmpDTO, LoginInfo>();
                 });
                 var mapper = new Mapper(config);
                 var data = mapper.Map<LoginInfo>(newStaff);

                 var DBcontext = new Zero_HungerEntities2 { };
                 DBcontext.LoginInfoes.Add(data);
                 DBcontext.SaveChanges();
                 var data2 = mapper.Map<Emplyo>(newStaff);

                 DBcontext.Emplyoes.Add(data2);
                 DBcontext.SaveChanges();*/

                var loginData = new LoginInfo
                {
                    Email = newStaff.Email,

                    Password = newStaff.Password,
                    AccountType = 3000,
                };

                var DBcontext = new Zero_HungerEntities2 { };
                DBcontext.LoginInfoes.Add(loginData);
                DBcontext.SaveChanges();

                var staffData = new Emplyo
                {
                    EName = newStaff.EName,
                    LId = loginData.Id,
                    Gender = newStaff.Gender,
                   Address = newStaff.Address
                };

                DBcontext.Emplyoes.Add(staffData);
                DBcontext.SaveChanges();

                return RedirectToAction("EmployeeList");
            }
            else
            {
                return View(newStaff);
            }
           
        }
        [HttpGet]
        public ActionResult ResturentList()
        {
            var DBcontext = new Zero_HungerEntities2 { };
            var joinedData = (from emp in DBcontext.Resturents
                              join login in DBcontext.LoginInfoes on emp.LId equals login.Id
                              where login.AccountType == 2000
                              select new ResturentView
                              {
                                  RName = emp.RName,
                                  Address = emp.Address,
                                  Id = emp.Id,
                                  Email = login.Email,
                              }).ToList();

            return View(joinedData);

        }
    }
}
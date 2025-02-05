﻿using ecommercesite.Identity;
using ecommercesite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommercesite.Entity;
namespace ecommercesite.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());

            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());

            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }



        // GET: Account 

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                // kayıt islemleri

                var user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;


                IdentityResult result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    // kulanıcı oluştu ve kullanıcıya bir rol ata.

                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterError", "Kullanıcı oluşturma başarısız oldu.");
                }

            }



            return View(model);
        }


        public ActionResult Login()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Login işlemleri 
                var user = UserManager.Find(model.UserName, model.Password);


                if (user != null)
                {
                    // varolan kullanıcıyı sisteme dahil etme.
                    //ApplicationCookie oluşturup sisteme bırak.

                    var authManager = HttpContext.GetOwinContext().Authentication;

                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");

                    var authProperties = new AuthenticationProperties();

                    authProperties.IsPersistent = model.RememberMe;

                    authManager.SignIn(authProperties, identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                       return  Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginError", "Böyle bir kullanıcı yok.");

                }
            }

           return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;



            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }


    }

}
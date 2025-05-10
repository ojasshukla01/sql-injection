using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult Index(User user)
        {

           
           var issqlInjectionOccuer = false;
            // check sql injection 

            CheckSqlInjection checkSqlInjection = new CheckSqlInjection ();
            issqlInjectionOccuer = checkSqlInjection.CheckFromPatern(user.Pws);
            if (issqlInjectionOccuer)
            {
                if (user.Email == "admin@myshop.com")
                { 
                    // avoid sql injection and go to next page
                    user.Pws = checkSqlInjection.ReplaceFromPatern(user.Pws);

                    user.Pws = checkSqlInjection.ReplcaeWords(user.Pws);


                
                }

                if (user.Email == "test1@gmail.com")
                {
                    // avoid sql injection and go to next page

                    user.Pws = checkSqlInjection.ReplaceFromPatern(user.Pws);

                    user.Pws = checkSqlInjection.ReplcaeWords(user.Pws);

                    Session["SqMessage"] = "Sql injection identifired";

                }

                if (user.Email == "user3@gmail.com")
                {

                    var sqlc = user.Pws;
                    // avoid sql injection and go to next page
                    user.Pws = checkSqlInjection.ReplaceFromPatern(user.Pws);

                    user.Pws = checkSqlInjection.ReplcaeWords(user.Pws);

                    sqlc = sqlc.Replace(user.Pws, "");
                    Session["InjString"] = sqlc;

                    return RedirectToAction("SQLInjectionMessage", "Home");
                }

            }

            MVCTestEntities _entity = new MVCTestEntities();

            var _result = _entity.Users.Where(x => x.Email == user.Email && x.Pws == user.Pws).ToList();

           if (_result.Count > 0)
           {
               Session["UserID"] = _result[0].UserID;
               if(user.Email =="admin@myshop.com")
                   return RedirectToAction("Index", "Admin");
               else
               return RedirectToAction("Index", "Shopping");


           }
           else
           {
               Session["UserID"] = null;
               return View();
           }
        }


    }
}

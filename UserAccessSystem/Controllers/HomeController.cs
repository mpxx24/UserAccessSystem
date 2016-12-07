using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UserAccessSystem.DatabaseAccess.Models;

namespace UserAccessSystem.Controllers {
    public class HomeController : Controller {
        // GET: Home
        public ActionResult Index() {
            return View();
        }

        public JsonResult GetAllUsers() {
            return Json(new UsersGridModel());
        }

        [Serializable]
        public class UsersGridModel {
            public UsersGridModel() {
                current = 1;
                rowCount = 10;
                rows = new List<User>
                {
                    new User
                    {
                        FirstName = "asd",
                        LastName = "asdasdasd",
                        LastSubscription = new DateTime(2014, 11, 30)
                    },
                    new User
                    {
                        FirstName = "qvq",
                        LastName = "gqw",
                        LastSubscription = new DateTime(2000, 11, 30)
                    },
                    new User
                    {
                        FirstName = "wgfvqvb",
                        LastName = "asdasasdxvsvdasd",
                        LastSubscription = new DateTime(1924, 11, 30)
                    }
                };
                total = 86;
            }
            public int current { get; set; }
            public int rowCount { get; set; }
            public List<User> rows { get; set; }
            public int total { get; set; }
        }
    }
}
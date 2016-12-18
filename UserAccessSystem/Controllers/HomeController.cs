using System.Web.Mvc;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Controllers {
    public class HomeController : Controller {
        private readonly IUserService userService;
        public HomeController(IUserService userService) {
            this.userService = userService;
        }

        public ActionResult Index() {
            return this.View();
        }

        public ActionResult AddUserPopup() {
            return this.View();
        }

        public ActionResult ApiTests() {
            return this.View();
        }
        public ActionResult Territory() {
            return this.View();
        }
    }
}
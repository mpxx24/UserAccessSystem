using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using UserAccessSystem.Models.Converters;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Controllers {
    public class HomeController : Controller {
        private readonly IUserService userService;
        public HomeController(IUserService userService) {
            this.userService = userService;
        }

        public ActionResult Index() {
            return View();
        }

        public ActionResult AddUserPopup() {
            return View();
        }

        public ActionResult ApiTests() {
            return View();
        }

        /// <summary>
        ///     Gets all users.
        /// </summary>
        /// <returns>
        ///     returns JSON string of all users for grid usage>
        /// </returns>
        public string GetAllUsers() {
            var users = userService.GetUserViewModels();
            var usersSorted = users.OrderByDescending(x => x.IsActiveAccount).ThenBy(x => x.LastName).ThenBy(x => x.FirstName);
            return JsonConvert.SerializeObject(UserModelConverter.ConvertUsersListToGridModel(usersSorted));
        }
    }
}
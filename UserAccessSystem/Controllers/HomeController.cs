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
            return this.View();
        }

        public ActionResult AddUserPopup() {
            return this.View();
        }

        public ActionResult ApiTests() {
            return this.View();
        }

        /// <summary>
        ///     Gets all users.
        /// </summary>
        /// <returns>
        ///     returns JSON string of all users for grid usage>
        /// </returns>
        public string GetAllUsers() {
            var users = this.userService.GetUserViewModels();
            var usersSorted = users.OrderBy(x => x.Id);
            return JsonConvert.SerializeObject(UserModelConverter.ConvertUsersListToGridModel(usersSorted));
        }
    }
}
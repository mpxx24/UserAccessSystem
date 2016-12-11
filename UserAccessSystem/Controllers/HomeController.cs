using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using UserAccessSystem.Models.Converters;
using UserAccessSystem.Models.Models.CustomControlsModels;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Controllers {
    public class HomeController : Controller {
        private readonly IUserService userService;
        public HomeController(IUserService userService) {
            this.userService = userService;
        }

        // GET: Home
        public ActionResult Index() {
            return View();
        }

        public ActionResult AddUserPopup() {
            var trueFalseDropdownList = new List<SelectListItem>
            {
                new SelectListItem {Value = "1", Text = "false"},
                new SelectListItem {Value = "2", Text = "true"}
            };

            return View(trueFalseDropdownList);
        }

        public string GetAllUsers() {
            var users = userService.GetUserViewModels();
            var usersSorted = users.OrderByDescending(x => x.IsActiveAccount).ThenBy(x => x.LastName).ThenBy(x => x.FirstName);
            return JsonConvert.SerializeObject(UserModelConverter.ConvertUsersListToGridModel(usersSorted));
        }
    }
}
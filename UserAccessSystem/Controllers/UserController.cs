using System;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UserAccessSystem.DatabaseAccess.Models;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Controllers {
    public class UserController : Controller {
        private readonly IUserService userService;
        public UserController(IUserService userService) {
            this.userService = userService;
        }

        public void SaveUser(string p) {
            const string dateFormat = "dd/MM/yyyy";
            var dtConverter = new IsoDateTimeConverter {DateTimeFormat = dateFormat};

            var userData = JsonConvert.DeserializeObject<User>(p, dtConverter);
            var user = UpdateUserData(userData);

            userService.SaveUser(user);
        }

        private static User UpdateUserData(User userData) {
            var user = new User
            {
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                LastSubscription = userData.LastSubscription,
                IsSuperUser = userData.IsSuperUser,
                DateOfBirth = userData.DateOfBirth,
                IsActiveAccount = userData.LastSubscription >= DateTime.Today.AddDays(-28)
            };
            return user;
        }
    }
}
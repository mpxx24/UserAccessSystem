using System;
using System.Web.Mvc;
using Newtonsoft.Json;
using UserAccessSystem.DatabaseAccess.Models;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Controllers {
    public class UserController : Controller {
        private readonly IUserService userService;
        public UserController(IUserService userService) {
            this.userService = userService;
        }
        
        public void SaveUser(string p) {
            var userData = JsonConvert.DeserializeObject<User>(p);
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                LastSubscription = userData.LastSubscription,
                IsSuperUser = userData.IsSuperUser,
                DateOfBirth = userData.DateOfBirth,
                IsActiveAccount = userData.LastSubscription >= DateTime.Today.AddDays(-28)
            };

            userService.SaveUser(user);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UserAccessSystem.DatabaseAccess.Models;
using UserAccessSystem.Models.Converters;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Controllers {
    public class UserController : Controller {
        private readonly IUserService userService;
        public UserController(IUserService userService) {
            this.userService = userService;
        }

        /// <summary>
        ///     Saves the user.
        /// </summary>
        /// <param name="p">The p.</param>
        public void SaveUser(string p) {
            const string dateFormat = "dd/MM/yyyy";
            var dtConverter = new IsoDateTimeConverter {DateTimeFormat = dateFormat};

            var userData = JsonConvert.DeserializeObject<User>(p, dtConverter);
            var nextId = this.userService.GetAllUsers().Max(x => x.Id) + 1;

            var user = UpdateUserData(userData, nextId);

            this.userService.SaveUser(user);
        }

        /// <summary>
        ///     Edits the user.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public ActionResult EditUser(int p) {
            return this.View(this.userService.GetUserViewModel(p));
        }

        /// <summary>
        ///     Updates the user.
        /// </summary>
        /// <param name="p">The p.</param>
        public void UpdateUser(string p) {
            const string dateFormat = "dd/MM/yyyy";
            var dtConverter = new IsoDateTimeConverter {DateTimeFormat = dateFormat};

            var userData = JsonConvert.DeserializeObject<User>(p, dtConverter);
            var userToUpdate = this.userService.GetUser(userData.Id);
            userToUpdate.FirstName = userData.FirstName;
            userToUpdate.LastName = userData.LastName;
            userToUpdate.LastSubscription = userData.LastSubscription;
            userToUpdate.IsActiveAccount = userData.LastSubscription >= DateTime.Today.AddDays(-28);

            this.userService.UpdateUser(userToUpdate);
        }

        /// <summary>
        ///     Deletes the user.
        /// </summary>
        /// <param name="p">The p.</param>
        public void DeleteUser(string p) {
            var ids = JsonConvert.DeserializeObject<List<int>>(p);
            foreach (var id in ids) {
                this.userService.DeleteUser(id);
            }
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

        /// <summary>
        ///     Updates the user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private static User UpdateUserData(User userData, int id) {
            var user = new User
            {
                Id = id,
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                LastSubscription = userData.LastSubscription,
                IsSuperUser = userData.IsSuperUser,
                DateOfBirth = userData.DateOfBirth,
                IsActiveAccount = userData.IsSuperUser || userData.LastSubscription >= DateTime.Today.AddDays(-28)
            };
            return user;
        }
    }
}
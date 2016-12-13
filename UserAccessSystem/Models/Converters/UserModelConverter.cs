using System.Collections.Generic;
using System.Linq;
using UserAccessSystem.DatabaseAccess.Models;
using UserAccessSystem.Models.AppModels;
using UserAccessSystem.Models.AppModels.CustomControlsModels;

namespace UserAccessSystem.Models.Converters {
    /// <summary>
    ///     Converter for <see cref="User" /> class
    /// </summary>
    public static class UserModelConverter {
        /// <summary>
        ///     Converts the users to API models.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        public static List<UserApiModel> ConvertUsersToApiModels(IEnumerable<User> users) {
            return users.Select(ConvertUserToApiModel).ToList();
        }

        /// <summary>
        ///     Converts the users to view models.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        public static List<UserViewModel> ConvertUsersToViewModels(IEnumerable<User> users) {
            return users.Select(ConvertUserToViewModel).ToList();
        }

        /// <summary>
        ///     Converts the users list to grid model.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns>
        ///     <see cref="UsersGridModel" />
        /// </returns>
        public static UsersGridModel ConvertUsersListToGridModel(IEnumerable<UserViewModel> users) {
            var userViewModels = users.ToList();
            var userGridModel = new UsersGridModel
            {
                Rows = userViewModels.ToList(),
                RowCount = 10,
                Total = userViewModels.Count(),
                Current = 1
            };

            return userGridModel;
        }

        public static UserApiModel ConvertUserToApiModel(User user) {
            return new UserApiModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActiveAccount = user.IsActiveAccount,
                IsSuperUser = user.IsSuperUser,
                LastSubscription = user.LastSubscription.ToShortDateString()
            };
        }

        private static UserViewModel ConvertUserToViewModel(User user) {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActiveAccount = user.IsActiveAccount,
                IsSuperUser = user.IsSuperUser,
                LastSubscription = user.LastSubscription
            };
        }
    }
}
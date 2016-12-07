using System.Collections.Generic;
using System.Linq;
using UserAccessSystem.DatabaseAccess.Models;
using UserAccessSystem.Models.Models;

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
        public static List<UserApiModel> ConvertUsersToApiModels(IList<User> users) {
            return users.Select(ConvertUserToApiModel).ToList();
        }

        private static UserApiModel ConvertUserToApiModel(User user) {
            return new UserApiModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActiveAccount = user.IsActiveAccount,
                IsSuperUser = user.IsSuperUser,
                LastSubscription = user.LastSubscription.ToShortDateString()
            };
        }
    }
}
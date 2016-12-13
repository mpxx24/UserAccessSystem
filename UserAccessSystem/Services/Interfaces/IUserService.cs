using System.Collections.Generic;
using UserAccessSystem.DatabaseAccess.Models;
using UserAccessSystem.Models.AppModels;

namespace UserAccessSystem.Services.Interfaces {
    /// <summary>
    ///     Interface for Service for all operations with <see cref="User" /> class
    /// </summary>
    public interface IUserService {
        /// <summary>
        ///     Gets all users.
        /// </summary>
        /// <returns>list of all users</returns>
        IEnumerable<User> GetAllUsers();

        /// <summary>
        ///     Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        UserApiModel GetUserApiModel(int id);

        /// <summary>
        ///     Gets the web API user model.
        /// </summary>
        /// <returns>
        ///     list of all users as user api models
        /// </returns>
        IEnumerable<UserApiModel> GetWebApiUserModels();

        /// <summary>
        ///     Gets the user view models.
        /// </summary>
        /// <returns>
        ///     list of all users as user view models
        /// </returns>
        IEnumerable<UserViewModel> GetUserViewModels();

        /// <summary>
        ///     Saves the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        int SaveUser(User user);
    }
}
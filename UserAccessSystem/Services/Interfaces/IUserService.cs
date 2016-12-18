using System.Collections.Generic;
using UserAccessSystem.DatabaseAccess.Models;
using UserAccessSystem.Models.AppModels;

namespace UserAccessSystem.Services.Interfaces {
    /// <summary>
    ///     Interface for Service for all operations with <see cref="User" /> class
    /// </summary>
    public interface IUserService {
        /// <summary>
        ///     Doeses the user with specified identifier exist.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        bool IsUserWithSpecifiedIdExist(int id);

        /// <summary>
        ///     Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        UserApiModel GetUserApiModel(int id);

        /// <summary>
        ///     Gets the user view model.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        UserViewModel GetUserViewModel(int id);

        /// <summary>
        ///     Saves the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        int SaveUser(User user);

        /// <summary>
        ///     Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        User GetUser(int id);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void UpdateUser(User user);

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        void DeleteUser(int userId);

        /// <summary>
        ///     Gets all users.
        /// </summary>
        /// <returns>list of all users</returns>
        IEnumerable<User> GetAllUsers();

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
    }
}
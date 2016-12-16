using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using UserAccessSystem.DatabaseAccess.Models;
using UserAccessSystem.Models.AppModels;
using UserAccessSystem.Models.Converters;
using UserAccessSystem.Repository;
using UserAccessSystem.Services.Exceptions;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Services {
    /// <summary>
    ///     Service for all operations with <see cref="User" /> class
    /// </summary>
    public class UserService : IUserService {
        private readonly IRepository repository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserService" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public UserService(IRepository repository) {
            this.repository = repository;
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public void DeleteUser(int userId) {
            var user = this.GetUser(userId);
            this.repository.Remove(user);
        }
        /// <summary>
        ///     Gets all users.
        /// </summary>
        /// <returns>
        ///     list of all users
        /// </returns>
        public IEnumerable<User> GetAllUsers() {
            return this.repository.GetAll<User>();
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public User GetUser(int id) {
            return this.repository.GetFirst<User>(x => x.Id == id);
        }

        /// <summary>
        ///     Gets the user API model.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public UserApiModel GetUserApiModel(int id) {
            if (!this.DoesUserWithSpecifiedIdExist(id)) {
                throw new ObjectNotFoundException("User with specified ID not found!");
            }

            var user = this.repository.GetFirst<User>(x => x.Id == id);
            return UserModelConverter.ConvertUserToApiModel(user);
        }

        /// <summary>
        ///     Gets the user view models.
        /// </summary>
        /// <returns>
        ///     list of all userts as use view models
        /// </returns>
        /// <exception cref="GeneralServiceMethodException">$Failed to retrieve user view models! - {nameof(GetUserViewModels)}</exception>
        public IEnumerable<UserViewModel> GetUserViewModels() {
            var users = this.GetAllUsers();
            try {
                return UserModelConverter.ConvertUsersToViewModels(users);
            }
            catch (Exception ex) {
                throw new GeneralServiceMethodException($"Failed to retrieve user view models! - {nameof(this.GetUserViewModels)}", ex.InnerException);
            }
        }

        /// <summary>
        ///     Saves the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        ///     Id of newly added user
        /// </returns>
        /// <exception cref="FailedToAddObjectToDatabaseException">User with specified ID already exists!</exception>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// </exception>
        /// <exception cref="GeneralServiceMethodException">$Failed to add user! - {nameof(SaveUser)}</exception>
        public int SaveUser(User user) {
            if (this.DoesUserWithSpecifiedIdExist(user.Id)) {
                throw new FailedToAddObjectToDatabaseException("User with specified ID already exists!");
            }
            if (string.IsNullOrEmpty(user.FirstName)) {
                throw new ArgumentNullException(nameof(user.FirstName));
            }
            if (string.IsNullOrEmpty(user.LastName)) {
                throw new ArgumentNullException(nameof(user.LastName));
            }
            if (user.DateOfBirth > DateTime.Today) {
                throw new ArgumentOutOfRangeException(nameof(user.DateOfBirth));
            }
            if (user.LastSubscription.Date > DateTime.Today) {
                throw new ArgumentOutOfRangeException(nameof(user.LastSubscription));
            }

            try {
                return this.repository.Add(user).Id;
            }
            catch (Exception ex) {
                throw new GeneralServiceMethodException($"Failed to add user! - {nameof(this.SaveUser)}", ex.InnerException);
            }
        }

        /// <summary>
        ///     Gets the web API user models.
        /// </summary>
        /// <returns>
        ///     list of all users as user api models
        /// </returns>
        public IEnumerable<UserApiModel> GetWebApiUserModels() {
            var users = this.GetAllUsers();
            return UserModelConverter.ConvertUsersToApiModels(users);
        }

        /// <summary>
        ///     Doeses the user with specified identifier exist.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool DoesUserWithSpecifiedIdExist(int id) {
            return this.repository.GetAll<User>().Any(x => x.Id == id);
        }

        /// <summary>
        ///     Gets the user view model.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.Entity.Core.ObjectNotFoundException">User with specified ID not found!</exception>
        public UserViewModel GetUserViewModel(int id) {
            if (!this.DoesUserWithSpecifiedIdExist(id)) {
                throw new ObjectNotFoundException("User with specified ID not found!");
            }

            var user = this.repository.GetFirst<User>(x => x.Id == id);
            return UserModelConverter.ConvertUserToViewModel(user);
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void UpdateUser(User user) {
            this.repository.Edit(user);
        }
    }
}
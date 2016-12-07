using System.Collections.Generic;
using System.Linq;
using UserAccessSystem.DatabaseAccess.Models;
using UserAccessSystem.Models.Converters;
using UserAccessSystem.Models.Models;
using UserAccessSystem.Repository;
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
        ///     Gets all users.
        /// </summary>
        /// <returns>
        ///     list of all users
        /// </returns>
        public IEnumerable<User> GetAllUsers() {
            return repository.GetAll<User>();
        }

        /// <summary>
        ///     Gets the web API user models.
        /// </summary>
        /// <returns>
        ///     list of all users as user api models
        /// </returns>
        public IEnumerable<UserApiModel> GetWebApiUserModels() {
            var users = GetAllUsers();
            return UserModelConverter.ConvertUsersToApiModels(users.ToList());
        }
    }
}
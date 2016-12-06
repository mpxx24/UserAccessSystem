using System.Collections.Generic;
using UserAccessSystem.DatabaseAccess.Models;
using UserAccessSystem.Repository;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Services {
    /// <summary>
    /// Service for all operations with <see cref="User"/> class
    /// </summary>
    public class UserService : IUserService {
        private readonly IRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public UserService(IRepository repository) {
            this.repository = repository;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>
        /// list of all users
        /// </returns>
        public IEnumerable<User> GetAllUsers() {
            return repository.GetAll<User>();
        }
    }
}
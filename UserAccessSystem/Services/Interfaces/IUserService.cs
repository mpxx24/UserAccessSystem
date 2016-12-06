using System.Collections.Generic;
using UserAccessSystem.DatabaseAccess.Models;

namespace UserAccessSystem.Services.Interfaces {
    /// <summary>
    ///     Interface for Service for all operations with <see cref="User"/> class
    /// </summary>
    public interface IUserService {
        /// <summary>
        ///     Gets all users.
        /// </summary>
        /// <returns>list of all users</returns>
        IEnumerable<User> GetAllUsers();
    }
}
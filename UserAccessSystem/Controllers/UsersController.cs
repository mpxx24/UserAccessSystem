using System.Collections.Generic;
using System.Web.Http;
using UserAccessSystem.DatabaseAccess.Models;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Controllers {
    public class UsersController : ApiController {
        private readonly IUserService userService;

        public UsersController(IUserService userService) {
            this.userService = userService;
        }

        // GET api/users
        public IEnumerable<User> Get() {
            return userService.GetAllUsers();
        }
    }
}
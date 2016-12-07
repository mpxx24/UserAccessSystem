using System.Collections.Generic;
using System.Web.Http;
using UserAccessSystem.Models.Models;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Controllers {
    public class UsersController : ApiController {
        private readonly IUserService userService;

        public UsersController(IUserService userService) {
            this.userService = userService;
        }

        // GET api/users
        public IEnumerable<UserApiModel> Get() {
            return userService.GetWebApiUserModels();
        }
    }
}
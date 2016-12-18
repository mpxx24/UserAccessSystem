using System.Collections.Generic;
using System.Web.Http;
using UserAccessSystem.Models.AppModels;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Controllers {
    public class UsersController : ApiController {
        private readonly IUserService userService;

        public UsersController(IUserService userService) {
            this.userService = userService;
        }

        /// <summary>
        ///    Gets all users as Web API models
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserApiModel> Get() {
            return this.userService.GetWebApiUserModels();
        }

        /// <summary>
        ///     Gets specified (with id) user Web API model
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public UserApiModel Get(int id) {
            return this.userService.GetUserApiModel(id);
        }
    }
}
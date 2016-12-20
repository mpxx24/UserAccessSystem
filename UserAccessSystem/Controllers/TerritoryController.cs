﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using UserAccessSystem.DatabaseAccess.Models;
using UserAccessSystem.Models.AppModels;
using UserAccessSystem.Models.AppModels.CustomControlsModels;
using UserAccessSystem.Models.Converters;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Controllers {
    public class TerritoryController : Controller {
        private readonly ITerritoryService territoryService;
        private readonly IUserService userService;

        public TerritoryController(ITerritoryService territoryService, IUserService userService) {
            this.territoryService = territoryService;
            this.userService = userService;
        }

        /// <summary>
        ///     Main Territories view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() {
            return this.View();
        }

        /// <summary>
        ///     Gets all territories.
        /// </summary>
        /// <returns></returns>
        public string GetAllTerritories() {
            var territories = this.territoryService.GetTerritoriesViewModels();
            var territoriesSorted = territories.OrderBy(x => x.Id);
            return JsonConvert.SerializeObject(TerritoryModelConverter.ConvertTerritoriesListToGridModel(territoriesSorted));
        }

        /// <summary>
        ///     Adds the territory popup.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddTerritoryPopup() {
            return this.View();
        }

        /// <summary>
        ///     Saves the territory.
        /// </summary>
        /// <param name="p">The p.</param>
        public void SaveTerritory(string p) {
            var userData = JsonConvert.DeserializeObject<Territory>(p);
            var nextId = this.territoryService.GetAllTerritories().Max(x => x.Id) + 1;

            var territory = UpdateTerritoryData(userData, nextId);

            this.territoryService.AddTerritory(territory);
        }

        private static Territory UpdateTerritoryData(Territory territory, int nextId) {
            return new Territory
            {
                Id = nextId,
                Name = territory.Name,
                ShortName = territory.ShortName,
                IsAvailableForAll = true,
                IsRequireSpecialUserAccessRights = false
            };
        }

        /// <summary>
        /// Assigns the users.
        /// </summary>
        /// <param name="p">The p.</param>
        public void AssignUsers(string p) {

        }

        /// <summary>
        /// Assigns the user to territories view
        /// </summary>
        /// <returns></returns>
        public ActionResult AssignUsersToTerritories() {
            var users = this.userService.GetUserViewModels();
            var territories = this.territoryService.GetAllTerritories();
            var usersModel = new DropdownListViewModel
            {
                Enumerable = new MultiSelectList(users.ToList(), "Id", "FullName")
            };

            var territoriesModel = new DropdownListViewModel
            {
                Enumerable = new MultiSelectList(territories.ToList(), "Id", "Name")
            };

            var assignModel = new AssignUserToTerritoryModel
            {
                Users = usersModel,
                Territories = territoriesModel
            };

            return this.View(assignModel);
        }
    }
}
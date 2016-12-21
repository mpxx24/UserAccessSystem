using System;
using System.Collections.Generic;
using System.Linq;
using UserAccessSystem.DatabaseAccess.Models;
using UserAccessSystem.Models.AppModels;
using UserAccessSystem.Models.Converters;
using UserAccessSystem.Repository;
using UserAccessSystem.Services.Exceptions;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Services {
    /// <summary>
    ///     Service for all operations with <see cref="Territory" /> class
    /// </summary>
    public class TerritoryService : ITerritoryService {
        private readonly IRepository repository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TerritoryService" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public TerritoryService(IRepository repository) {
            this.repository = repository;
        }

        /// <summary>
        /// Gets the territory API model.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TerritoryApiModel GetTerritoryApiModel(int id) {
            var territory = this.repository.GetFirst<Territory>(x => x.Id == id);
            return TerritoryModelConverter.ConvertTerritoryToApiModel(territory);
        }

        /// <summary>
        ///     Gets all territories.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Territory> GetAllTerritories() {
            return this.repository.GetAll<Territory>();
        }

        /// <summary>
        ///     Gets the territory.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Territory GetTerritory(int id) {
            return this.repository.GetFirst<Territory>(x => x.Id == id);
        }

        /// <summary>
        ///     Determines whether [is territory f or special users only] [the specified identifier].
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool IsTerritoryFOrSpecialUsersOnly(int id) {
            return this.repository.GetFirst<Territory>(x => x.Id == id).IsRequireSpecialUserAccessRights;
        }

        /// <summary>
        ///     Adds the territory.
        /// </summary>
        /// <param name="territory">The territory.</param>
        /// <returns></returns>
        /// <exception cref="FailedToAddObjectToDatabaseException">Territory with sepcified ID already exists!</exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public int AddTerritory(Territory territory) {
            if (this.IsTerritoryWithSpecifiedIdExist(territory.Id)) {
                throw new FailedToAddObjectToDatabaseException("Territory with sepcified ID already exists!");
            }
            if (string.IsNullOrEmpty(territory.Name)) {
                throw new ArgumentNullException(nameof(territory.Name));
            }

            try {
                return this.repository.Add(territory).Id;
            }
            catch (Exception ex) {
                throw new GeneralServiceMethodException($"Failed to add territory! - {nameof(this.AddTerritory)}", ex.InnerException);
            }
        }

        /// <summary>
        /// Updates the territory.
        /// </summary>
        /// <param name="territory">The territory.</param>
        public void UpdateTerritory(Territory territory) {
            try {
                this.repository.Edit(territory);
            }
            catch (Exception ex) {
                throw new GeneralServiceMethodException($"Failed to update territory! - {nameof(this.UpdateTerritory)}", ex.InnerException);
            }
        }

        /// <summary>
        /// Gets the territories view models.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="GeneralServiceMethodException">$Failed to retrieve territory view models! - {nameof(this.GetTerritoriesViewModels)}</exception>
        public IEnumerable<TerritoryViewModel> GetTerritoriesViewModels() {
            var territories = this.GetAllTerritories();
            try {
                return TerritoryModelConverter.ConvertTerritoriesToViewModels(territories);
            }
            catch (Exception ex) {
                throw new GeneralServiceMethodException($"Failed to retrieve territory view models! - {nameof(this.GetTerritoriesViewModels)}", ex.InnerException);
            }
        }

        /// <summary>
        /// Gets the territory API models.
        /// </summary>
        /// <param name="territories">The territories.</param>
        /// <returns></returns>
        public IEnumerable<TerritoryApiModel> GetTerritoryApiModels(IEnumerable<Territory> territories) {
            return TerritoryModelConverter.ConvertTerritoriesToApiModels(territories);
        }

        private bool IsTerritoryWithSpecifiedIdExist(int id) {
            return this.repository.GetAll<Territory>().Any(x => x.Id == id);
        }
    }
}
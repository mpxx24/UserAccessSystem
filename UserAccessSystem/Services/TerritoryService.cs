using System;
using System.Collections.Generic;
using System.Linq;
using UserAccessSystem.DatabaseAccess.Models;
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

        private bool IsTerritoryWithSpecifiedIdExist(int id) {
            return this.repository.GetAll<Territory>().Any(x => x.Id == id);
        }
    }
}
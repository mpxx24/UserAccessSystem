﻿using System.Collections.Generic;
using UserAccessSystem.DatabaseAccess.Models;
using UserAccessSystem.Models.AppModels;

namespace UserAccessSystem.Services.Interfaces {
    public interface ITerritoryService {
        /// <summary>
        ///     Gets the territory.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Territory GetTerritory(int id);

        /// <summary>
        ///     Determines whether [is territory f or special users only] [the specified identifier].
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        bool IsTerritoryFOrSpecialUsersOnly(int id);

        /// <summary>
        ///     Adds the territory.
        /// </summary>
        /// <param name="territory">The territory.</param>
        /// <returns></returns>
        int AddTerritory(Territory territory);

        /// <summary>
        ///     Gets all territories.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Territory> GetAllTerritories();

        /// <summary>
        /// Gets the territories view models.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TerritoryViewModel> GetTerritoriesViewModels();
    }
}
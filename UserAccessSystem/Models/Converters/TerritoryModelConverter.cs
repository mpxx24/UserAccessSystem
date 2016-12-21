using System.Collections.Generic;
using System.Linq;
using UserAccessSystem.DatabaseAccess.Models;
using UserAccessSystem.Models.AppModels;
using UserAccessSystem.Models.AppModels.CustomControlsModels;

namespace UserAccessSystem.Models.Converters {
    public class TerritoryModelConverter {
        /// <summary>
        ///     Converts the territories to view models.
        /// </summary>
        /// <param name="territories">The territories.</param>
        /// <returns></returns>
        public static List<TerritoryViewModel> ConvertTerritoriesToViewModels(IEnumerable<Territory> territories) {
            return territories.Select(ConvertTerritoryToViewModel).ToList();
        }

        /// <summary>
        ///     Converts the territories list to grid model.
        /// </summary>
        /// <param name="territories">The territories.</param>
        /// <returns></returns>
        public static TerritoriesGridModel ConvertTerritoriesListToGridModel(IEnumerable<TerritoryViewModel> territories) {
            var territoriesViewModel = territories.ToList();
            return new TerritoriesGridModel
            {
                Rows = territoriesViewModel.ToList(),
                RowCount = 0,
                Total = territoriesViewModel.Count(),
                Current = 1
            };
        }

        /// <summary>
        ///     Converts the territory to API model.
        /// </summary>
        /// <param name="territory">The territory.</param>
        /// <returns></returns>
        public static TerritoryApiModel ConvertTerritoryToApiModel(Territory territory) {
            return new TerritoryApiModel
            {
                Name = territory.Name,
                ShortName = territory.ShortName
            };
        }

        /// <summary>
        ///     Converts the territories to API models.
        /// </summary>
        /// <param name="territories">The territories.</param>
        /// <returns></returns>
        public static List<TerritoryApiModel> ConvertTerritoriesToApiModels(IEnumerable<Territory> territories) {
            return territories.Select(ConvertTerritoryToApiModel).ToList();
        }

        private static TerritoryViewModel ConvertTerritoryToViewModel(Territory territory) {
            return new TerritoryViewModel
            {
                Id = territory.Id,
                Name = territory.Name,
                ShortName = territory.ShortName,
                IsAvailableForAll = territory.IsAvailableForAll,
                IsRequireSpecialUserAccessRights = territory.IsRequireSpecialUserAccessRights
            };
        }
    }
}
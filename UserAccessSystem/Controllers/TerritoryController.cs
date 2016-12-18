using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using UserAccessSystem.Models.Converters;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Controllers {
    public class TerritoryController : Controller {
        private readonly ITerritoryService territoryService;
        public TerritoryController(ITerritoryService territoryService) {
            this.territoryService = territoryService;
        }

        /// <summary>
        /// Main Territories view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() {
            return this.View();
        }

        /// <summary>
        /// Gets all territories.
        /// </summary>
        /// <returns></returns>
        public string GetAllTerritories() {
            var territories = this.territoryService.GetTerritoriesViewModels();
            var territoriesSorted = territories.OrderBy(x => x.Id);
            return JsonConvert.SerializeObject(TerritoryModelConverter.ConvertTerritoriesListToGridModel(territoriesSorted));
        }
    }
}
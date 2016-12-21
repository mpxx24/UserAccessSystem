using System.Collections.Generic;
using System.Web.Http;
using UserAccessSystem.Models.AppModels;
using UserAccessSystem.Services.Interfaces;

namespace UserAccessSystem.Controllers {
    public class TerritoriesController : ApiController {
        private readonly ITerritoryService territoryService;
        public TerritoriesController(ITerritoryService territoryService) {
            this.territoryService = territoryService;
        }

        public IEnumerable<TerritoryApiModel> Get() {
            var territories = this.territoryService.GetAllTerritories();
            return this.territoryService.GetTerritoryApiModels(territories);
        }

        public TerritoryApiModel Get(int id) {
            return this.territoryService.GetTerritoryApiModel(id);
        }
    }
}
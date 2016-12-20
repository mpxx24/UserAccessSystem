using UserAccessSystem.Models.AppModels.CustomControlsModels;

namespace UserAccessSystem.Models.AppModels {
    /// <summary>
    /// AssignUserToTerritoryModel model
    /// </summary>
    public class AssignUserToTerritoryModel {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DropdownListViewModel Users { get; set; }

        /// <summary>
        /// Gets or sets the territories.
        /// </summary>
        /// <value>
        /// The territories.
        /// </value>
        public DropdownListViewModel Territories { get; set; }
    }
}
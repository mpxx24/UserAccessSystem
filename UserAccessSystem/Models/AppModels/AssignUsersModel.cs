using System.Collections.Generic;

namespace UserAccessSystem.Models.AppModels {
    /// <summary>
    ///     AssignUsersModel model from assign users to territory view
    /// </summary>
    public class AssignUsersModel {
        /// <summary>
        ///     Gets or sets the territory identifier.
        /// </summary>
        /// <value>
        ///     The territory identifier.
        /// </value>
        public int TerritoryId { get; set; }

        /// <summary>
        ///     Gets or sets the user ids.
        /// </summary>
        /// <value>
        ///     The user ids.
        /// </value>
        public List<int> UserIds { get; set; }
    }
}
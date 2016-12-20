using System.Web.Mvc;

namespace UserAccessSystem.Models.AppModels.CustomControlsModels {
    public class DropdownListViewModel {
        /// <summary>
        /// Gets or sets the ids.
        /// </summary>
        /// <value>
        /// The ids.
        /// </value>
        public int[] Ids { get; set; }

        /// <summary>
        /// Gets or sets the enumerable.
        /// </summary>
        /// <value>
        /// The enumerable.
        /// </value>
        public MultiSelectList Enumerable { get; set; }
    }
}